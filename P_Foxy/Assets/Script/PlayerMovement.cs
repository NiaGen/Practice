using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D player;
	public float speed = 1f;
	bool directionR = true;
	private Animator animator;


	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		if (move != 0.0f) {
			animator.SetFloat("Player_run", 1.0f);
		} else {
			animator.SetFloat("Player_run", 0.0f);
		}
//		animator.SetFloat("Player_run", move);
		player.velocity = new Vector2 (move * speed, player.velocity.y);

		if (move > 0 && !directionR)
		{
			Flip ();
		}
		else if (move < 0 && directionR)
		{
			Flip ();
		}
	}

	void Flip()
	{
		directionR = !directionR;
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
