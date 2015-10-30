using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SettingsControl : MonoBehaviour {

	GameObject start_menu;
	GameObject settings;

	// pretty much a global... fix?
	static Slider master_volume;

	// Use this for initialization
	void Start () {
		start_menu = GameObject.Find("start_menu");
		settings = GameObject.Find("settings");

		master_volume = GameObject.Find ("settings/MasterVolume").GetComponent<Slider>();

		master_volume.value = PlayerPrefs.GetFloat("master_volume", 1);
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void loadMain()
	{
		start_menu.SetActive (true);
		//map_select.SetActive (false);
		//char_select.SetActive (false);
		settings.SetActive (false);

		Save ();
	}



	// just saves volume right now
	public static void Save() {
		PlayerPrefs.SetFloat ("master_volume", master_volume.value);
		/*
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/settings.gd");

		float tmpData = master_volume.value;

		bf.Serialize(file, tmpData);
		file.Close();
		*/


	}

	/*
	public static void Load() {
		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			SaveLoad.savedGames = (List<Game>)bf.Deserialize(file);
			file.Close();
		}
	}*/
}
