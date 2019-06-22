using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealCam : MonoBehaviour {

	private	float	timer = 1f;
	private Vector3	offset;

	void Update() {
		if (timer > 0f) {
			timer -= (Time.deltaTime / 4f);
			offset = transform.position + (Random.insideUnitSphere * (0.3f * timer));
			transform.position = Vector3.Lerp (transform.position, offset, timer);
			Camera.main.nearClipPlane = Mathf.Lerp(0f, 50f, timer);
		} else {
			this.enabled = false;
		}
	}
}
