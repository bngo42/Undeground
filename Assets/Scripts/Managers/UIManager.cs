using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager uim;
	
	public GameObject[]	panels;
	public Text			broadcaster;
	public Text			timer;
	public Slider		hungerBar;
	public Image		backdrop;

	void Awake () {
		if (uim == null) {
			uim = this;
		}
	}

	public void broadcastMessage(string msg) {
		broadcaster.text = msg;
	}
	
	public void switchScreen(string name){
		for (int i = 0; i < panels.Length; i++) {
			panels[i].SetActive(panels[i].name == name);
		}
	}

	public void setHungerValue(float h) {
		hungerBar.value = h;
	}

	public void setTimerValue(float t) {
		timer.text = "timer " + (Mathf.Round(t)).ToString();
	}

	public void fadeInImage(Image element, float duration = 1f) {
		element.canvasRenderer.SetAlpha(0f);
		element.CrossFadeAlpha(1, duration, false);
	}

	public void fadeOutImage(Image element, float duration = 1f) {
		element.canvasRenderer.SetAlpha(1f);
		element.CrossFadeAlpha(0, duration, false);
	}
	
	public void fadeInText(Text element, float duration = 1f) {
		element.canvasRenderer.SetAlpha(0f);
		element.CrossFadeAlpha(1, duration, false);
	}

	public void fadeOutText(Text element, float duration = 1f) {
		element.canvasRenderer.SetAlpha(1f);
		element.CrossFadeAlpha(0, duration, false);
	}

	public void fadeInBackdrop() {
		fadeInImage(backdrop);
	}

	public void fadeOutBackdrop() {
		fadeOutImage(backdrop);
	}
}
