using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PowerUpMenu : MonoBehaviour {

	public Text scoreText;

	public Image BackgroundImg;
	private bool visible = false;
	private float transition;
	private float animationTime;
	private bool enemyKilled = false;

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(!visible){
			return;
		}

		scoreText.text = ((int)GameObject.Find("Player").GetComponent<Score>().score).ToString();
		animationTime += Time.deltaTime;

		if(animationTime < 1.0f){
			transition += Time.deltaTime;
			BackgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.white, transition);	
		}
		else if(animationTime > 1.0f && enemyKilled == false){
			transition = 0.0f;
			GameObject.Find("Tile Manager").GetComponent<TileManager>().kill_all_enemy();
			enemyKilled = true;
		}
		else if(animationTime > 3.0f && animationTime < 4.0f){
			transition += Time.deltaTime;
			BackgroundImg.color = Color.Lerp(Color.white, new Color(0, 0, 0, 0), transition);
		}
		else if(animationTime > 4.0f){
			gameObject.SetActive(false);
			visible = false;
			enemyKilled = false;
		}
		
	}

	public void TogglePowerMenu(){
		gameObject.SetActive(true);
		visible = true;
		animationTime = 0.0f;
		transition = 0.0f;
	}

}
