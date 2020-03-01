using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
	public Vector2 lastVelocity;

	private Ball ball;

    void Start()
    {
		ball = GetComponent<Ball>();
		ball.rb.velocity = ball.playerVelocity;

    }
		
    void Update()
    {
		foreach (Touch touch in Input.touches) {
			if (ball.TouchArea.Contains (touch.position) && touch.phase == TouchPhase.Began && !PauseMenu.GameIsPaused) {
				AudioManager.instance.Play ("Whoosh");
				ball.rb.velocity = -ball.rb.velocity;
				lastVelocity = ball.rb.velocity;
			}
		}

		if (ball.rb.velocity.y == 0f) {
			ball.rb.velocity = -lastVelocity;
		}
    }
}
