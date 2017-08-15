using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIsland : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 15.0f);
	}

}
