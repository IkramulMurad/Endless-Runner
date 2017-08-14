using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPosition : MonoBehaviour {

	private bool positionChanged = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(positionChanged) return;
		setPosition();
	}

	private void setPosition(){
		int[] xPos = {-2, 0, 2};
		int randomNumber = Random.Range(0, 3);
		Vector3 pos = transform.position;

		pos.x = xPos[randomNumber];
		transform.position = pos;

		positionChanged = true;
	}
}
