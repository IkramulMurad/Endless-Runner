using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	private Rigidbody rb;
	private Vector3 moveVector;
	
	private float speed = 5.0f;
	private float jumpSpeed = 5.0f;
	private float jumpFactor = 100.0f;
	private bool isDead;
	private bool canJump;
	private float deltaX;
	private float xUnit = 2.0f;
	private float eps = 0.1f;

	private float startTime;
	private float animationDuration = 3.0f;

	// Use this for initialization
	void Start () {
		isDead = false;
		canJump = true;
		startTime = Time.time;
		rb = GetComponent<Rigidbody>();
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
		speed = 5.0f + modifier;
	}

	private void OnCollisionEnter(Collision hit){
		if(hit.gameObject.tag.Contains("Enemy")){
			dead();
		}

		if(hit.gameObject.tag.Contains("Tile")){
			canJump = true;
		}
	}

	private void dead(){
		isDead = true;
		GetComponent<Score>().OnDeath();
	}

}