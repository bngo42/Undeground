using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObjects : MonoBehaviour {

	public	Transform			target;
	private List<RaycastHit>	previous = new List<RaycastHit>();

	void Update () {
		Vector3 dir = (target.position - transform.position);
		RaycastHit[] current = Physics.RaycastAll(transform.position, dir, dir.magnitude);
		List<RaycastHit> hits = new List<RaycastHit>(current);

		if (previous.Count > 0) {
			for (int j = 0; j < previous.Count; j++) {
				if (!hits.Contains(previous[j]) && previous[j].transform != target) {
					setObjectOpaque(previous[j].transform);
				}
			}
		}
		if (hits.Count > 0) {
			previous = new List<RaycastHit>();
			for (int k = 0; k < hits.Count; k++)
				previous.Add(hits[k]);
		}

		for (int i = 0; i < hits.Count; i++) {
			if (hits[i].transform != target) {
				setObjectTransparent(hits[i].transform);
			}
		}
	}

	public void setObjectTransparent(Transform obj) {
		setObjectAlpha(obj, 0.3f);
	}

	public void setObjectOpaque(Transform obj) {
		setObjectAlpha(obj, 1f);
	}

	public void setObjectAlpha(Transform obj, float alpha) {
		Renderer rend = obj.GetComponent<Renderer>();

		if (rend) {
			rend.material.shader = Shader.Find((alpha < 1f) ? "Transparent/Diffuse" : "Standard");
			Color tempColor = rend.material.color;
			tempColor.a = alpha;
			rend.material.color = tempColor;
		}
	}

}
