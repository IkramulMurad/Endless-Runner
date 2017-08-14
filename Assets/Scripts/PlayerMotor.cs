using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	private Rigidbody rb;
	private Vector3 moveVector;
	public bool isDead;

	private float speed = 10.0f;
	private float initSpeed = 10.0f;
	private float jumpSpeed = 5.0f;
	private float jumpFactor = 100.0f;
	private bool canJump;
	private float deltaX;
	private float xUnit = 2.0f;
	private float eps = 0.1f;

	private float startTime;
	private float animationDuration = 3.0f;
	private AudioSource deathSound;
	private AudioSource powerSound;

	// Use this for initialization
	void Start () {
		isDead = false;
		canJump = true;
		startTime = Time.time;
		rb = GetComponent<Rigidbody>();
		deathSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	//to rewrite
	void Update () {

		if(isDead){
			return;
		}

		if(Time.time - startTime < animationDuration){
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
			return;
		}


		//player movement through x axis
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if (Mathf.Abs(transform.position.x - xUnit) < eps)
				deltaX = 0;
			else
				deltaX = xUnit;

			transform.position += new Vector3 (deltaX, 0.0f, 0.0f);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			if (Mathf.Abs(transform.position.x + xUnit) < eps)
				deltaX = 0;
			else
				deltaX = -xUnit;

			transform.position += new Vector3 (deltaX, 0.0f, 0.0f);
		}

		//player movement through y axis
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			jump();
		}

		//player movement through z axis
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

	private void jump(){
		if(canJump){
			rb.AddForce(Vector3.up * jumpSpeed * jumpFactor);
			canJump = false;
		}
	}

	public void set_speed(int modifier){
		speed = initSpeed + modifier;
	}

	private void OnCollisionEnter(Collision hit){
		if(hit.gameObject.tag.Contains("Enemy")){
			deathSound.Play();
			dead();
		}

		if(hit.gameObject.tag.Contains("Tile")){
			canJump = true;
		}

		if(hit.gameObject.tag.Contains("Power_shake")){
			powerSound = hit.gameObject.transform.parent.gameObject.GetComponent<AudioSource>();
			powerSound.Play();
			Destroy(hit.gameObject);
			GameObject.Find("Main Camera").GetComponent<CameraShake>().shakecamera();
		}
		if(hit.gameObject.tag.Contains("Power_splash")){
			powerSound = hit.gameObject.transform.parent.gameObject.GetComponent<AudioSource>();
			powerSound.Play();
			Destroy(hit.gameObject);
			GetComponent<Score>().OnPowerUp();
		}
	}

	private void dead(){
		isDead = true;
		GetComponent<Score>().OnDeath();
	}

}