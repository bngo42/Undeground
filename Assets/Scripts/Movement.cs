using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float 			playerSpeed = 1f;
	public ParticleSystem 	particles;
	private bool			isUnderground = false;
	private bool			canMove = true;

	private Rigidbody 		rb;
	private Renderer		rend;
	private Material		currentMat;
	private IEnumerator		corrToggleMode;

	void Start () {
		rb = GetComponent<Rigidbody>();
		rend = GetComponent<Renderer>();
	}
	
	void FixedUpdate () {
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -transform.up, out hit, 10f)) {
			Renderer objRend = hit.transform.GetComponent<Renderer>();
			if (objRend) {

				currentMat = objRend.material;
				ParticleSystem.MainModule main = particles.main;
				main.startColor = currentMat.color;
			}
		}
		if (corrToggleMode == null && Input.GetButtonDown("Fire3")){
			if (!hit.transform.gameObject.layer.Equals(LayerMask.NameToLayer("Floor"))){
				isUnderground = !isUnderground;
				Debug.Log("Switch mode !");
				rb.velocity = Vector3.zero;
				corrToggleMode = toggleMode();
				StartCoroutine(corrToggleMode);
			}

		}

		if (canMove && GameManager.gm.canMove) {
			Vector3 vel = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
			rb.velocity = Vector3.ClampMagnitude((vel * (playerSpeed * 4f)), 4f);
		}
	}

	public void switchLayer(string layerName) {
		if (!string.IsNullOrEmpty(layerName)) {
			gameObject.layer = LayerMask.NameToLayer(layerName);
		}
	}

	IEnumerator toggleMode() {
		canMove = false;
		yield return new WaitForSeconds(1f);
		rend.enabled = !isUnderground;
		if (isUnderground){
			switchLayer("PlayerUnderground");
			particles.Play();
		} else {
			switchLayer("PlayerOverground");
			particles.Stop();
		}
		canMove = true;
		corrToggleMode = null;
	}
}
