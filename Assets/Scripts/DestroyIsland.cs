using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIsland : MonoBehaviour {

	private Transform camera;

	void Start () {
		camera = GameObject.Find("Main Camera").transform;
	}

	void Update() {
		if ( transform.position.z < camera.position.z ) {
			Destroy(this.gameObject, 1.5f);
		}
	}

}
