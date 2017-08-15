using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionAndRotation : MonoBehaviour {

	private bool positionChanged = false;
	private bool rotationChanged = false;
	private int lastPosIndex = -1;
	private int lastRotIndex = -1;

	public bool changePosition = true;
	public bool changeRotation = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!positionChanged && changePosition){
			change_position();
		}
		if(!rotationChanged && changeRotation){
			change_rotation();
		}
	}

	private void change_rotation(){
		float[] yRot = {0f, 26f, 56f, 87f, 130f, 155f, 220f, 293f, 350f};
		int randomNumber = random_index(0, yRot.Length, lastRotIndex);
		Vector3 originalAngles = transform.rotation.eulerAngles;

		transform.rotation = Quaternion.Euler(originalAngles.x, yRot[randomNumber], originalAngles.z);
		rotationChanged = true;

		// Debug.Log("index: " + randomNumber + "\n" + "val: " + yRot[randomNumber]);
		// Debug.Log("x: " + transform.rotation.x + "\n" + "y: " + transform.rotation.eulerAngles.y);
	}

	private void change_position(){
		int[] xPos = {-2, 0, 2};
		int randomNumber = random_index(0, xPos.Length, lastPosIndex);
		Vector3 pos = transform.position;

		pos.x = xPos[randomNumber];
		transform.position = pos;

		positionChanged = true;
	}

	private int random_index(int min, int max, int lastIndex){
		int randomIndex = lastIndex;

		while(randomIndex == lastIndex){
			randomIndex = Random.Range(min, max);
		}

		return randomIndex;
	}
}
