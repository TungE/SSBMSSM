using UnityEngine;
using System.Collections;

public class CharSelectButtonControl : MonoBehaviour {

	public static int playerNum;

	// Use this for initialization
	void Start () {
		playerNum = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void selectChar0()
	{
		PlayerPrefs.SetInt ("P" + playerNum.ToString(), 0);
		++playerNum;
	}
	public void selectChar1()
	{
		PlayerPrefs.SetInt ("P" + playerNum.ToString(), 1);
		++playerNum;
	}
	public void selectChar2()
	{
		PlayerPrefs.SetInt ("P" + playerNum.ToString(), 2);
		++playerNum;
	}
	public void selectChar3()
	{
		PlayerPrefs.SetInt ("P" + playerNum.ToString(), 3);
		++playerNum;
	}
}
