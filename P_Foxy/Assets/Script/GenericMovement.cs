using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMovement : MonoBehaviour {

	public float speed = 1.0f;
	public float jumpHeight = 0.5f;
	private Rigidbody2D player;
	public bool directionR = true;
	private Animator animator;
	private bool isJumping;


	// Use this for initialization
	protected virtual void Start () {
		player = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
		
/*	// Update is called once per frame
	void Update(){
		Debug.Log (jumpCheck);
	}
*/
	void FixedUpdate () {
		float move = Input.GetAxisRaw ("Horizontal");
		if (move != 0.0f) {
			animator.SetFloat("Player_run", 1.0f);
		} else {
			animator.SetFloat("Player_run", 0.0f);
		}

		player.velocity = new Vector2 (move * speed, player.velocity.y);

		if (move > 0 && !directionR) {
			Flip ();
		}
		else if (move < 0 && directionR) {
			Flip ();
		}
			
		if (Input.GetKeyDown ("space") && isJumping == false) {
			player.velocity = new Vector2 (player.velocity.x,jumpHeight); 
			isJumping = true;
			animator.SetBool("Player_jump", true);
		}

	}

	protected virtual void Flip()
	{
		directionR = !directionR;
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.CompareTag ("Ground"))
		{
			isJumping = false;
			animator.SetBool("Player_jump", false);
		}
	}
/*	void OnCollisionExit2D(Collision2D collider)
	{
		if (collider.gameObject.CompareTag ("Ground"))
		{
			isJumping = true;
			animator.SetBool("Player_jump", true);
		}
	}*/
}
