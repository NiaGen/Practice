using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D player;
	private int collectedItems;
	private int lifes;
	private bool onLadder;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		player = GetComponent<Rigidbody2D> ();
		lifes = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (animator.GetBool("Player_hurt") == true && lifes > 0)
		{
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collider){
		if (collider.gameObject.CompareTag ("Enemy"))
		{
			animator.SetBool ("Player_hurt", true);
			Destroy(player.GetComponent<BoxCollider2D>());
			player.constraints = RigidbodyConstraints2D.FreezeAll;
		}
		else
		{
			animator.SetBool ("Player_hurt", false);
		}
	}
	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.CompareTag ("Enemy"))
		{
			Destroy(collider.GetComponent<BoxCollider2D>());
			collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
			collider.GetComponent<Animator>().Play ("pop");
			collider.gameObject.tag = "Untagged";
			Destroy (collider.gameObject, 1);
			player.velocity = new Vector2 (player.velocity.x, 3.0f);
		}
		if (collider.gameObject.CompareTag ("Item"))
		{
			collectedItems++;
			collider.GetComponent<Animator>().Play ("Collected");
			Destroy (collider.gameObject, 0.6f);
		}
		if(collider.name == "Player")
	}
}
