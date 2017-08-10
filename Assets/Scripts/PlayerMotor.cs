using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	private CharacterController controller;
	private Vector3 moveVector;
	
	private float speed = 5.0f;
	private float verticalVelocity = 0.0f;
	private float gravity = 10.0f;
	private bool isDead = false;
	private float startTime;

	private float currentX;
	private float deltaX;

	private float animationDuration = 3.0f;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(isDead){
			return;
		}

		if(Time.time - startTime < animationDuration){
			controller.Move(Vector3.forward * speed * Time.deltaTime);
			return;
		}

		moveVector = Vector3.zero;

		if(controller.isGrounded){
			verticalVelocity = 0.0f;
		}
		else{
			verticalVelocity -= gravity * Time.deltaTime;
		}

		//x
		//moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
		//y
		moveVector.y = verticalVelocity;
		//z
		moveVector.z = speed;

		controller.Move (moveVector * Time.deltaTime);

		//player movement through x axis
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if (transform.position.x == 2.0f)
				deltaX = 0;
			else
				deltaX = 2.0f;

			transform.position += new Vector3 (deltaX, 0.0f, 0.0f);
			//Debug.Log(transform.position.x);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			if (transform.position.x == -2.0f)
				deltaX = 0;
			else
				deltaX = -2.0f;

			transform.position += new Vector3 (deltaX, 0.0f, 0.0f);
			//Debug.Log(transform.position.x);
		}
	}

	public void set_speed(int modifier){
		speed = 5.0f + modifier;
	}

	private void OnControllerColliderHit(ControllerColliderHit hit){
		if(hit.collider.tag == "Enemy"){
			dead();
			//Debug.Log(hit.collider.tag);
		}
	}

	private void dead(){
		isDead = true;
		GetComponent<Score>().OnDeath();
	}

}
