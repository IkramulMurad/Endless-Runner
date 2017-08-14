using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Text highScoreText;

	private float score;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("Highscore")){
			score = PlayerPrefs.GetFloat("Highscore");
		}
		else{
			score = 0.0f;
		}
		highScoreText.text = "Highscore : " + ((int)score).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToGame(){
		SceneManager.LoadScene("Game");
	}
}
