using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
	public Text score;
	public Text highScore;
	public bool ballisActive = true;
	public int number = 0;

	void Start () {
		highScore.enabled = true;
		highScore.text = "HighScore : " + PlayerPrefs.GetInt ("HighScore", 0).ToString();
	}

	public void addPoints () {
		if (ballisActive) {
			number++;
			score.text = number.ToString ();
		}

		if (number > PlayerPrefs.GetInt ("HighScore", 0)) {
			PlayerPrefs.SetInt ("HighScore", number);
		}
	}

	public void resetPoints() {
		PlayerPrefs.DeleteKey ("HighScore");
		highScore.text = "HighScore : 0 ";
	}

	public void disableText() {
		highScore.enabled = false;
	}
}
