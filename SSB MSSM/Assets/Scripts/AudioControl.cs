using UnityEngine;
using System.Collections;

public class AudioControl : MonoBehaviour {

	AudioSource audio;

	// doesn't get destroyed when loading brawl scene
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start() {
		audio = GetComponent<AudioSource>();
	}

	// listen to the settings volume
	void Update() {
		audio.volume = PlayerPrefs.GetFloat ("master_volume", 1);
	}
}
