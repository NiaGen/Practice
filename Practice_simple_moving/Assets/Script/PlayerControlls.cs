using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour {

	public float speed = 10f;
	private Rigidbody2D player;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		float moveHor = Input.GetAxis ("Horizontal");
		player.velocity = new Vector2 (moveHor * speed, player.velocity.y);
	}
}
