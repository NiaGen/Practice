﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UiItemAnimation : MonoBehaviour {

	[SerializeField]
	private Image icon;
	[SerializeField]
	private Sprite[] animationFrames = new Sprite[10];
	private bool animateIt = true;

	// Use this for initialization
	void Start () {
		icon = icon.GetComponent<Image> ();
		StartCoroutine (coroutine());
	}

	 IEnumerator coroutine () {
		while (animateIt) {
			foreach (Sprite item in animationFrames) {
				if (animationFrames != null) {
					icon.sprite = item;
					yield return new WaitForSeconds (0.1f);
				}
			}
		}
	}
}
