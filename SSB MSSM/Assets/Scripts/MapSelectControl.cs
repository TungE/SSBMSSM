using UnityEngine;
using System.Collections;

public class MapSelectControl : MonoBehaviour {
	
	GameObject map_select;
	GameObject char_select;

	// Use this for initialization
	void Start () {
		map_select = GameObject.Find("map_select");
		char_select = GameObject.Find("char_select");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void selectMap0 ()
	{
		PlayerPrefs.SetInt ("map", 0);
		LoadCharSelect ();
	}
	public void selectMap1 ()
	{
		PlayerPrefs.SetInt ("map", 1);
		LoadCharSelect ();
	}
	public void selectMap2 ()
	{
		PlayerPrefs.SetInt ("map", 2);
		LoadCharSelect ();
	}

	public void LoadCharSelect()
	{
		//if (gameData.Capacity > 0) // if map has been selected
		//{
		char_select.SetActive (true);
		// settings.SetActive (false);
		// start_menu.SetActive (false);
		map_select.SetActive (false);
		//}
	}
}
