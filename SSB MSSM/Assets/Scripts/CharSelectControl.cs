using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharSelectControl : MonoBehaviour {

	public Selectable playButton;
	// another global... fix?
	public static int playerNum;

	// Use this for initialization
	void Start () {
		playButton = GameObject.Find ("Play").GetComponent<Selectable>();// GameObject.Find ("Play");
		playButton.interactable = false;
		//playButton. (false);
		playerNum = 1;
	}
	
	// Update is called once per frame
	void Update () {
		// when the users have selected at least two players
		if (PlayerPrefs.HasKey ("P1") && PlayerPrefs.HasKey ("P2")) 
		{
			// they can start playing
			//playButton.SetActive (true); 
			playButton.interactable = true;
		}
	}
	

	public void LoadGame()
	{
		Application.LoadLevel ("brawl");
	}	
}
