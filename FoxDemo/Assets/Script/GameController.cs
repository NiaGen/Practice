using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public bool keyPressed;
	private int collectedGems;
	private int collectedCherrys;
	private int lifes;
	[SerializeField]
	private Text haveGems;
	[SerializeField]
	private Text haveCherrys;
	[SerializeField]
	private Text haveLifes;

	void Awake(){
		Instancenate ();
		CalculateItems ();
	}


	void OnEnable(){
		SceneManager.sceneLoaded += LevelIsLoaded;
	}

	void OnDisable(){
		SceneManager.sceneLoaded -= LevelIsLoaded;
	}
	void LevelIsLoaded(Scene scene, LoadSceneMode sceneMode){
		if (scene.name == "Level_1") {
			if (!GameManager.instance.needToRespawn) {
				collectedGems = 0;
				collectedCherrys = 90;
				lifes = 3;
			} else {
				collectedGems = GameManager.instance.collectedGems;
				collectedCherrys = GameManager.instance.collectedCherrys;
				lifes = GameManager.instance.lifes;
			}
			CalculateItems ();
		}
	}

	public void GameOver(){
		if (lifes <= 0){
				SceneManager.LoadScene("EndGame");
		}else if(lifes > 0){
			SceneManager.LoadScene("Level_1");
			GameManager.instance.needToRespawn = true;
			GameManager.instance.collectedGems = collectedGems;
			GameManager.instance.collectedCherrys = collectedCherrys;
			GameManager.instance.lifes = lifes;
		}
		LifeUp ();
	}

	public void LifeUp(){
		if (collectedCherrys >= 100) {
			lifes++;
			collectedCherrys = 0;
			CalculateItems ();
		}
	}

	private void Instancenate(){
		if (instance == null) {
			instance = this;
		}
	}

	public void CalculateItems (){
		haveGems.text = "" + collectedGems.ToString ();
		haveCherrys.text = "" + collectedCherrys.ToString ();
		haveLifes.text = "Lifes = " + lifes.ToString ();
	}

	public void AddGem(){
		collectedGems++;
		CalculateItems ();
	}

	public void AddCherry(){
		collectedCherrys++;
		CalculateItems ();
	}

	public void DebuffGem(){
		collectedGems--;
		CalculateItems ();
	}

	public void GetHurt(){
		lifes--;

		CalculateItems ();
		GameOver ();
	}
}
