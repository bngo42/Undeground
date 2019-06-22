using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform	target;
	public float		damping = 0.3f;
	private Vector3		offset;

	void Start() {
		offset = transform.localPosition;
	}

	void FixedUpdate () {
		if (target != null) {
			transform.position = Vector3.Lerp(transform.position, target.position + offset, damping);
		}
	}
}
