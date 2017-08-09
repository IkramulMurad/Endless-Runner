using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject[] tilePrefabs;

	private Transform playerTransform;
	private float spawnZ = 0.0f;
	private float tileLength = 10.0f;
	private int tileOnScreen = 5;

	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		for(int i = 0; i < tileOnScreen; ++i){
			spawn_tile();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(playerTransform.position.z > (spawnZ - tileOnScreen * tileLength)){
			spawn_tile();
		}
	}

	private void spawn_tile(int prefabIndex = 0){
		GameObject tile;
		tile = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
		tile.transform.SetParent(transform);
		tile.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
	}
}
