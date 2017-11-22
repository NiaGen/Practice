﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuyBox : MonoBehaviour {

	[SerializeField]
	private GameObject explosion;
	[SerializeField]
	private GameObject box;
	private bool destroyed;
	[SerializeField]
	private GameObject[] items = new GameObject[9];
	private Vector2 boxPosition;

	// Use this for initialization
	void Start () {
		destroyed = false;
	}

	// Update is called once per frame
	void Update () {
		boxPosition = transform.position;
		if (destroyed == true){
			foreach (GameObject item in items){
					Instantiate(item, boxPosition, Quaternion.identity);
				}
			box.tag = "Untagged";
			Instantiate (explosion, transform.position, Quaternion.identity);
			gameObject.SetActive (false);

			}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.name == "Player") {
			collider.GetComponent<Rigidbody2D>().velocity = new Vector2 (collider.GetComponent<Rigidbody2D>().velocity.x, 3.0f);
			destroyed = true;
			GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			GetComponent<BoxCollider2D> ().enabled = false;;
		}
	}
}
