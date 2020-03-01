using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqaureSpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	public float respawnTime = 1.0f;
	public float startTime;

	private Vector2 screenBounds;
	private HighScore highscore;

    void Start()
    {
		highscore = GameObject.Find ("GameManager").GetComponent<HighScore> ();
		screenBounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, Camera.main.transform.position.z));
		StartCoroutine (asteroidWave ());
    }
	private void spawnEnemy() {
		GameObject a = Instantiate (enemyPrefab) as GameObject;
		a.transform.position = new Vector2 (screenBounds.x * 2, Random.Range(-screenBounds.y + 0.5f, screenBounds.y - 0.5f));
	}
	IEnumerator asteroidWave(){
		while (true) {
			yield return new WaitForSeconds (respawnTime);
			spawnEnemy ();
		}
	}

	void Update() {

		if (Time.timeSinceLevelLoad - startTime >= 45f || highscore.number >= 100f) {
			respawnTime = 0.45f;
		}
		else if (Time.timeSinceLevelLoad - startTime >= 20f) {
			respawnTime = 0.6f;
		}
	}
}
