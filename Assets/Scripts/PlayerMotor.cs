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

	private float animationDuration = 3.0f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(isDead){
			return;
		}

		if(Time.time < animationDuration){
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
		moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
		//y
		moveVector.y = verticalVelocity;
		//z
		moveVector.z = speed;

		controller.Move (moveVector * Time.deltaTime);
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
