using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuControl : MonoBehaviour {

	public GameObject menu;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		/*
		// if time = 0 , visible
		if (Time.timeScale == 0.0f) 
		{
			foreach (Selectable selectableUI in Selectable.allSelectables) 
			{
				selectableUI.enabled = true;
				selectableUI.GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
				selectableUI.GetComponentInChildren<Text>().color = Color.black;
			}
		} 
		else 
		{
			foreach (Selectable selectableUI in Selectable.allSelectables) 
			{
				selectableUI.enabled = false;
				selectableUI.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
				selectableUI.GetComponentInChildren<Text>().color = Color.clear;
			}
		}*/
	}
}
