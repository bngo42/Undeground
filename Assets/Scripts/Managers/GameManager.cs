using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager gm;

	void Awake () {
		if (gm == null){
			gm = this;
		}	
	}

	public void pauseGame() {
		Time.timeScale = 0f;
	}

	public void resumeGame() {
		Time.timeScale = 1f;
	}
	
}
