using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

	private Transform playerTransform;
	private Vector3 initialDistance;

	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindWithTag("Player").transform;
		initialDistance = transform.position - playerTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = playerTransform.position + initialDistance;
	}
}
