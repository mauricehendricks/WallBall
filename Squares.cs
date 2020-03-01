using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Squares : MonoBehaviour
{
	public bool playernotDead;

	private bool hasNotPassed;
	private float speed = 3.0f;
	private Rigidbody2D rb;
	private Vector2 screenBounds;
	private GameObject ball_location;
	private HighScore highscore;

    void Start()
    {
		hasNotPassed = true;
		playernotDead = true;
		ball_location = GameObject.FindGameObjectWithTag ("PlayerLocation");
		rb = this.GetComponent<Rigidbody2D> ();
		highscore = GameObject.Find("GameManager").GetComponent<HighScore> ();
		rb.velocity = new Vector2 (-speed, 0);
		screenBounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, Camera.main.transform.position.z));
    }
		
    void Update()
	{
		if (transform.position.x < ball_location.transform.position.x && hasNotPassed == true) {
			hasNotPassed = false;
			highscore.addPoints ();
		}

		if (transform.position.x < -screenBounds.x * 1.25) {
			Destroy (this.gameObject);
		}
	}
}