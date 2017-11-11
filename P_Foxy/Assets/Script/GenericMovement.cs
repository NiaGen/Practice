using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMovement : MonoBehaviour {

	public float speed = 1.0f;
	public float jumpHeight = 0.5f;
	private Rigidbody2D player;
	public bool directionR = true;
	private Animator animator;
	private bool jumpCheck;


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
		float moveVert = Input.GetAxisRaw ("Vertical");
		float move = Input.GetAxisRaw ("Horizontal");
		if (move != 0.0f) {
			animator.SetFloat("Player_run", 1.0f);
		} else {
			animator.SetFloat("Player_run", 0.0f);
		}

//		if (jumpCheck == false) {
			player.velocity = new Vector2 (move * speed, player.velocity.y);
//		}

		if (move > 0 && !directionR) {
			Flip ();
		}
		else if (move < 0 && directionR) {
			Flip ();
		}
			
		if (Input.GetKeyDown ("space") && jumpCheck == false) {
			player.velocity = new Vector2 (player.velocity.x,jumpHeight); 
			jumpCheck = true;
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

	void OnCollisionEnter2D(Collision2D hit)
	{
		if (hit.gameObject.CompareTag ("Ground"))
		{
			jumpCheck = false;
			animator.SetBool("Player_jump", false);
		}
	}
	void OnCollisionExit2D(Collision2D nohit)
	{
		jumpCheck = true;
	}
}
