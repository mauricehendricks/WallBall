using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashScreen : MonoBehaviour {
	public float timer = 4.5f;
	public string levelToLoad = "Menu";

	void Start () {
		StartCoroutine ("DisplayScene");
	}
	
	IEnumerator DisplayScene() {
		yield return new WaitForSeconds (timer);
		SceneManager.LoadScene (levelToLoad);
		AudioManager.instance.Play ("Intro Music");
		AudioManager.playIntro = false;
	}
}
