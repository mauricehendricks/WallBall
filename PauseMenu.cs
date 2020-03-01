using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

	public static bool GameIsPaused = false;
	public GameObject soundControlButton;
	public GameObject pauseMenuUI;

	public Sprite audioOffSprite;
	public Sprite audioOnSprite;
		
    void Update()
    {
		if (AudioListener.volume < 1f ) {
			soundControlButton.GetComponent<Image> ().sprite = audioOffSprite;
		} else if (AudioListener.volume > 0f) {
			soundControlButton.GetComponent<Image> ().sprite = audioOnSprite;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (GameIsPaused) {
				Resume ();
			} else {
				Pause ();
			}
		}
    }

	public void Resume () {
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Pause () {
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void LoadMenu() {
		Time.timeScale = 1f;
		GameIsPaused = false;
		Ball.StartIsPressed = false;
		AudioManager.instance.Play ("Intro Music");
		AudioManager.instance.resetVolume ("Intro Music");
		AudioManager.playIntro = false;
		SceneManager.LoadScene ("Menu");
	}

	public void RestartGame() {
		Time.timeScale = 1f;
		GameIsPaused = false;
		Ball.StartIsPressed = false;
		SceneManager.LoadScene ("Game");
	}

	public void SoundControl () {
		if (AudioListener.volume < 1f) {
			AudioListener.volume = 1f;
		} else if (AudioListener.volume > 0f) {
			AudioListener.volume = 0f;
		}
	}
}
