﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : GenericMovement {

	private Rigidbody2D enemy;
	private float direction;
	private Animator enemyAnimator;

	// Use this for initialization
	protected override void Start () {
		enemy = GetComponent<Rigidbody2D>();
		enemyAnimator = GetComponent<Animator> ();
		direction = 1.0f;
		InvokeRepeating ("ChangeDirection", 2.0f, 2.0f);
		base.Start ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		enemy.velocity = new Vector2 (direction * speed, enemy.velocity.y);
		if (direction == -1.0f && !directionR) {
			Flip ();
		} else if (direction != -1.0f && directionR) {
			Flip ();
		}
	}

	void ChangeDirection() {
		if (direction == 1.0f) {
			direction = -1.0f;
		} else if (direction != 1.0f) {
			direction = 1.0f;
		}
	}



	protected override void Flip()
	{
		base.Flip ();
	}
}
