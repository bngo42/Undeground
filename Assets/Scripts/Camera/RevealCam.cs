using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealCam : MonoBehaviour {

	public	static	RevealCam	rc;
	public	float	animationSpeed = 2f;
	private	float	timer = 1f;
	private Vector3	offset;

	void Awake() {
		if (rc == null) {
			rc = this;
		}
	}

	public IEnumerator revealLevel() {
		GameManager.gm.canMove = false;
		timer = 1f;
		for(;;) {
			timer -= (Time.deltaTime / animationSpeed);
			updateState();
			if (timer <= 0f) {
				GameManager.gm.canMove = true;
				break ;
			}
			yield return null;
		}
	}

	public IEnumerator hideLevel() {
		GameManager.gm.canMove = false;
		timer = 0f;
		for(;;) {
			timer += (Time.deltaTime / animationSpeed);
			updateState();
			if (timer >= 1f) {
				GameManager.gm.canMove = true;
				break ;
			}
			yield return null;
		}
	}

	private void updateState() {
		offset = transform.position + (Random.insideUnitSphere * (0.3f * timer));
		transform.position = Vector3.Lerp (transform.position, offset, timer);
		Camera.main.nearClipPlane = Mathf.Lerp(0f, 50f, timer);
	}
}
