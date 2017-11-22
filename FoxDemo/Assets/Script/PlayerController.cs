﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;

	private Animator animator;
	private bool canExit;
//	public bool playerHurt;
	private Rigidbody2D player;
	GenericMovement genMov;

	void Start () {
		genMov = GetComponent<GenericMovement>();
		animator = GetComponent<Animator> ();
		player = genMov.player;
		canExit = false;
	}

	public void Update () {
		if (canExit == true && Input.GetKeyDown (KeyCode.E)) {
			SceneManager.LoadScene("Level_2");
		}
	}

	public void OnCollisionEnter2D(Collision2D collider){
		if (collider.gameObject.CompareTag ("Enemy")){
//			playerHurt = true;
			GameController.instance.GetHurt ();
			animator.SetBool ("Player_hurt", true);
//			Destroy(player.GetComponent<BoxCollider2D>());
//			player.constraints = RigidbodyConstraints2D.FreezeAll;
			player.velocity = new Vector2 (player.velocity.x, 3.0f);
		}
		else{
			GameController.instance.keyPressed = false;
			animator.SetBool ("Player_hurt", false);
		}
	}
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag ("Enemy")) {
			collider.GetComponent<BoxCollider2D> ().enabled = false;
			collider.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			collider.GetComponent<Animator> ().Play ("pop");
			collider.gameObject.tag = "Untagged";
			Destroy (collider.gameObject, 1);
			player.velocity = new Vector2 (player.velocity.x, 3.0f);
		}

		if (collider.gameObject.CompareTag ("Gem")) {
			GameController.instance.AddGem ();
			collider.GetComponent<Animator> ().Play ("Collected");
			Destroy (collider.gameObject, 0.6f);
		}
		if (collider.gameObject.CompareTag ("Cherry")) {
			GameController.instance.AddCherry ();
			collider.GetComponent<Animator> ().Play ("Collected");
			Destroy (collider.gameObject, 0.6f);
		}
		if (collider.gameObject.CompareTag ("RigidItem")) {
			GameController.instance.DebuffGem ();
			collider.GetComponent<Animator> ().Play ("Collected");
			collider.GetComponent<BoxCollider2D> ().enabled = false;
			collider.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			Destroy (collider.gameObject, 0.6f);
		}
		if (collider.name == "ExitDoor" && collider.GetComponent<Door> ().isOpened) {
			canExit = true;
		}

	}
}