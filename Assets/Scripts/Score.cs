using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Text scoreText;
	public DeathMenu deathMenu;

	private float score = 0.0f;
	private int difficultyLevel = 1;
	private int maxDifficultyLevel = 5;
	private int scoreToNextLevel = 10;

	private bool isPlayerDead = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isPlayerDead){
			return;
		}

		if(score > scoreToNextLevel){
			level_up();
		}

		score += Time.deltaTime * difficultyLevel;
		scoreText.text = ((int)score).ToString();
	}

	void level_up(){
		if(difficultyLevel == maxDifficultyLevel){
			return;
		}

		scoreToNextLevel *= 2;
		difficultyLevel++;

		GetComponent<PlayerMotor>().set_speed(difficultyLevel-1);
	}

	public void OnDeath(){
		isPlayerDead = true;
		deathMenu.ToggleEndMenu(score);

		if(PlayerPrefs.HasKey("Highscore")){
			if(score > PlayerPrefs.GetFloat("Highscore")){
				PlayerPrefs.SetFloat("Highscore", score);	
			}
		}
		else{
			PlayerPrefs.SetFloat("Highscore", score);
		}

	}
}
