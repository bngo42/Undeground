using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager gm;
	
	//Global Parameters
	
	[HideInInspector]public bool	canMove = true;
	[HideInInspector]public bool	isUnder = false;
	[HideInInspector]public bool	gameStarted = false;	

	[HideInInspector]public int 	currentScore = 0;
	[HideInInspector]public float 	hunger = 20f;
	[HideInInspector]public float 	reduceSpeed = 1f;

	[HideInInspector]public float	timer;

	void Awake () {
		if (gm == null){
			gm = this;
		}	
	}

	void Start() {
		UIManager.uim.fadeInBackdrop();
		UIManager.uim.switchScreen("StartScreen");
	}

	public void StartGameCoroutine() {
		StartCoroutine(StartGame());
	}

	public void StopGameCoroutine() {
		StartCoroutine(StopGame());
	}
	
	public void StartCountdownCoroutine() {
		StartCoroutine(startCountdown(3));
	}

	public IEnumerator startCountdown(int begin) {
		int count = (begin + 1);
		for (;;) {
			count--;
			UIManager.uim.broadcastMessage((count > 0) ? count.ToString() : "START");
			yield return new WaitForSeconds(1f);
			if (count <= 0) {
				UIManager.uim.broadcastMessage("");
				UIManager.uim.switchScreen("GameScreen");
				break ;
			}
		}
	}

	public IEnumerator StartGame() {
		GameManager.gm.canMove = false;
		StartCoroutine(RevealCam.rc.revealLevel());
		yield return new WaitForSeconds(RevealCam.rc.animationSpeed);
		gameStarted = true;
		Debug.Log("Starting game !");
		GameManager.gm.canMove = true;
	}

	public IEnumerator StopGame() {
		GameManager.gm.canMove = false;
		StartCoroutine(RevealCam.rc.hideLevel());
		yield return new WaitForSeconds(RevealCam.rc.animationSpeed);
		gameStarted = false;
		Debug.Log("Starting game !");
		GameManager.gm.canMove = true;
	}

	void Update() {
		if (gameStarted) {
			timer += Time.deltaTime;
			hunger -= (Time.deltaTime * (reduceSpeed * ((isUnder) ? 2f : 1f)));
			UIManager.uim.setTimerValue(timer);
			UIManager.uim.setHungerValue(hunger);
		}
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
