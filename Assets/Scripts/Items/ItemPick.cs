using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour {

	void OnTriggerStay(Collider col) {
		if (col.tag == "Player" && col.gameObject.layer.Equals(LayerMask.NameToLayer("PlayerOverground"))) {
			GameManager.gm.updateScore(10);
			gameObject.SetActive(false);
		}
	}
}
