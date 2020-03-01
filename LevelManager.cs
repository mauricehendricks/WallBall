using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel(string name){
		if (name == "Menu" && AudioManager.playIntro == true) {
			AudioManager.instance.Play ("Intro Music");
			AudioManager.instance.resetVolume ("Intro Music");
			AudioManager.playIntro = false;
		} else if (name == "Game") { // Disable this to continue Music in Game Scene
			AudioManager.instance.Reduce ("Intro Music");
			AudioManager.playIntro = true;
		}
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
		Application.Quit ();
	}
}
