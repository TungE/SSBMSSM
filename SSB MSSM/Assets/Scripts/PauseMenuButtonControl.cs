using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuButtonControl : MonoBehaviour {

	public GameObject pauseMenuCanvas;

	// Use this for initialization
	void Start () {
		pauseMenuCanvas = GameObject.Find ("pause_menu");
		pauseMenuCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Time.timeScale == 0.0f) {
			pauseMenuCanvas.SetActive(true);
		}*/
	}

	public void resumeGame() {
		pauseMenuCanvas.SetActive (false);
		Time.timeScale = 1.0f;
	}
	public void exitGame() {
		Application.LoadLevel("main_menu");
		
		// reset the user's map and character choices
		PlayerPrefs.DeleteKey ("map");
		PlayerPrefs.DeleteKey ("P1");
		PlayerPrefs.DeleteKey ("P2");
	}
}
