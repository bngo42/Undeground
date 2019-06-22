using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateItem : MonoBehaviour {

	public float 		animationSpeed;
	public float 		animationLength;
	public float		xSpeedAxis;
	public float		ySpeedAxis;
	public float		zSpeedAxis;

	private Vector3		pos;
	private Quaternion 	rot;

	void Start () {
		pos = transform.position;
	}
	
	void Update () {
		animateCoin ();
	}

	void animateCoin(){
		pos.y += Mathf.Sin ((Time.time) * (Time.timeScale * animationSpeed)) * (0.01f * animationLength);
		transform.position = pos;
		var rotation = Time.timeScale * (animationSpeed / 2);
		transform.Rotate (new Vector3 (rotation * (xSpeedAxis * 0.1f),rotation * (ySpeedAxis * 0.1f),rotation * (zSpeedAxis * 0.1f)));
	}
}
