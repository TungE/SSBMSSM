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
	
	}

	public void resumeGame() {
		pauseMenuCanvas.SetActive (false);
		Time.timeScale = 1.0f;
	}
	public void exitGame() {
		Application.LoadLevel("main_menu");
	}
}
