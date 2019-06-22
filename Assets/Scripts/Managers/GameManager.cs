using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager gm;
	
	//Global Parameters
	[HideInInspector]
	public bool		canMove = true;

	[HideInInspector]
	public int currentScore = 0;

	void Awake () {
		if (gm == null){
			gm = this;
		}	
	}

	void Start() {
		StartCoroutine(RevealCam.rc.revealLevel());
	}

	void Update() {

	}

	public void pauseGame() {
		Time.timeScale = 0f;
	}

	public void resumeGame() {
		Time.timeScale = 1f;
	}

	public void updateScore(int val) {
		currentScore += val;
	}
}
