using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySize : MonoBehaviour {
	private bool isIncreased = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isIncreased) return;
		increase();
	}

	private void increase(){
		isIncreased = true;

		int randomNumber = Random.Range(0, 10);

		if(randomNumber % 2 == 0){
			Vector3 scale = transform.localScale;
			Vector3 pos = transform.position;
			scale.y *= 2;
			pos.y *= 2;

			transform.localScale = scale;
			transform.position = pos;
		}
	}
}
