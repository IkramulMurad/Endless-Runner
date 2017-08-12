using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

	private Transform playerTransform;
	private Vector3 initialDistance;
	private Vector3 moveVector;

	private float transition = 0.0f;
	private float animationDuration = 3.0f;
	private Vector3 animationStartingPos = new Vector3(0, 5, 5);
	private float fixedY;

	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		initialDistance = transform.position - playerTransform.position;

		fixedY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		moveVector = playerTransform.position + initialDistance;

		// Let the camera shake when needed.
		if (gameObject.GetComponent<CameraShake> ().shaketrue == false) {
			moveVector.x = 0.0f;
		}

		if(transition > 1.0f){
			if (gameObject.GetComponent<CameraShake> ().shaketrue == false) {
				moveVector.y = fixedY;
			} else {
				moveVector.x = transform.position.x;
				moveVector.y = transform.position.y;
			}

			transform.position = moveVector;
		}
		else{
			transform.position = Vector3.Lerp(moveVector + animationStartingPos, moveVector, transition);
			transition += (1 / animationDuration) * Time.deltaTime;
			transform.LookAt(playerTransform.position + Vector3.up);
		}
	}
}
