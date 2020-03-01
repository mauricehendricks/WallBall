using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Rigidbody2D rb;
	public GameObject explosion;
	public Rect TouchArea;
	public Vector2 playerVelocity;

	private SqaureSpawner ss;
	private CanvasScript cs;
	private GameManager Gm;
	private CameraShake shake;
	private RipplePostProcessor camRipple;
	private HighScore highscore;

	public static bool StartIsPressed = false;
	public Vector3 startPosition = new Vector3 (-3.0f, -4.5f, 0f);

	public void Start() {
		TouchArea = new Rect (0, 0, Screen.width, Screen.height - 125f);
		
		rb = GetComponent<Rigidbody2D>();
		cs = GetComponent<CanvasScript>();
		ss = GameObject.Find("Main Camera").GetComponent<SqaureSpawner>();
		Gm = GameObject.Find("GameManager").GetComponent<GameManager> ();
		shake = GameObject.FindGameObjectWithTag ("screenShake").GetComponent<CameraShake> ();
		camRipple = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<RipplePostProcessor> ();
		highscore = GameObject.Find("GameManager").GetComponent<HighScore> ();

		cs.enabled = false;
		ss.enabled = false;

		playerVelocity = new Vector2 (0f, 12f);
	}

	public void Update () {
		foreach (Touch touch in Input.touches) {
			if (TouchArea.Contains (touch.position) && touch.phase == TouchPhase.Began && !StartIsPressed && !PauseMenu.GameIsPaused) {
				StartIsPressed = true;
				AudioManager.instance.Play ("Whoosh");
				cs.enabled = true;
				ss.enabled = true;
				highscore.disableText ();
				ss.startTime = Time.timeSinceLevelLoad;
			}
		}
	}

	public void OnCollisionEnter2D(Collision2D col) {
		if (col.transform.name == "Top Border") {
			rb.velocity = new Vector2 (0f, -10f);
			highscore.addPoints ();
			AudioManager.instance.Play ("Bounce");
		} else if (col.transform.name == "Bottom Border") {
			rb.velocity = new Vector2 (0f, 10f);
			highscore.addPoints ();
			AudioManager.instance.Play ("Bounce");
		}

		if (col.gameObject.tag == "Enemy") {
			GameObject other = col.gameObject;
			//Destroy(other); <----- Destroy and Collect Points Mode
			highscore.ballisActive = false;
			shake.Camshake ();
			camRipple.RippleEffect ();
			AudioManager.instance.Play("Player Death");
			Gm.setDeath ();
			Instantiate (explosion, transform.position, Quaternion.identity);
			//Deactivate this for Weird Physics Mode (Add Borders On all 4 sides)
			this.gameObject.SetActive(false);
		}
	}
}
