using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	public float respawnTime = 1.0f;

	private Vector2 screenBounds;

	void Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, Camera.main.transform.position.z));
		StartCoroutine (asteroidWave ());
	}
	private void spawnEnemy() {
		GameObject a = Instantiate (enemyPrefab) as GameObject;
		a.transform.localScale = new Vector3 (0.55f, 0.55f, 0f);
		a.transform.position = new Vector2 (screenBounds.x * 2, Random.Range(-screenBounds.y + 0.5f, screenBounds.y - 0.5f));
	}
	IEnumerator asteroidWave(){
		while (true) {
			yield return new WaitForSeconds (respawnTime);
			spawnEnemy ();
		}
	}
		
}
