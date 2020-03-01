using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
	public Text volumeText;
	public void resetPoints() {
		PlayerPrefs.DeleteKey ("HighScore");
	}

	public void SoundControl () {
		if (AudioListener.volume < 1f) {
			AudioListener.volume = 1f;
		} else if (AudioListener.volume > 0f) {
			AudioListener.volume = 0f;
		}
	}

	public void Update () {
		if (AudioListener.volume < 1f ) {
			volumeText.text = "Sound: Off".ToString (); 
		} else if (AudioListener.volume > 0f) {
			volumeText.text = "Sound: On".ToString ();
		}
	}
}
