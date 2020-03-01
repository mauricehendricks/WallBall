using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public bool death;

    void Start()
    {
		death = false;   
    }

	public bool setDeath() {
		return death = true;
	}
		
    void Update()
    {
		if (death) {
			StartCoroutine (reset ());
		}
    }

	 IEnumerator reset() {
			while (true) {
			yield return new WaitForSeconds (1.75f);
			Ball.StartIsPressed = false;
			SceneManager.LoadScene ("Game");
		}
	}
}
