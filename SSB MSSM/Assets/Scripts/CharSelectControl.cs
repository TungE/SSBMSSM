using UnityEngine;
using System.Collections;

public class CharSelectControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	public void LoadGame()
	{
		//if (gameData.chars.Capacity - 1 >= 2) // if at least (2) characters have been selected
		Application.LoadLevel ("brawl");
	}

	public void selectChar()
	{
		// gameData.chars.add(     );
	}
}
