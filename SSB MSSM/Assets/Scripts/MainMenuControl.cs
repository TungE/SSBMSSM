using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuControl : MonoBehaviour {
	
	GameObject start_menu;
	GameObject map_select;
	GameObject char_select;
	GameObject settings;


	private bool initialized = false; 

	// Use this for initialization
	void Start () {
		
		// GameData gameData;

		start_menu = GameObject.Find("start_menu");
		map_select = GameObject.Find("map_select");
		char_select = GameObject.Find("char_select");
		settings = GameObject.Find("settings");
	}
	
	// Update is called once per frame
	void Update () {
		if (!initialized) {
			loadMain();
			initialized = true;
		}
	}

	public void loadMain()
	{
		// start_menu.SetActive (true);
		map_select.SetActive (false);
		char_select.SetActive (false);
		settings.SetActive (false);
	}
	public void LoadMapSelect()
	{
		map_select.SetActive (true);
		// char_select.SetActive (false);
		// settings.SetActive (false);
		start_menu.SetActive (false);
	}
	public void LoadSettings()
	{
		settings.SetActive (true);
		// char_select.SetActive (false);
		// map_select.SetActive (false);
		start_menu.SetActive (false);
	}
	public void ExitGame()
	{
		Application.Quit ();
	}
}
