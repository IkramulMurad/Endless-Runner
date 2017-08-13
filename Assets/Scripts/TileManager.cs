using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject[] tilePrefabs;

	private Transform playerTransform;
	private float spawnZ = 0.0f;
	private float tileLength = 20.0f;
	private int tileOnScreen = 5;
	private float safeZone = 30.0f;
	private int lastPrefabIndex = 0;
	private List<GameObject> activeTiles;

	// Use this for initialization
	void Start () {
		activeTiles = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		for(int i = 0; i < tileOnScreen; ++i){
			if(i < 3){
				spawn_tile(0);
			}
			else{
				spawn_tile();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if((playerTransform.position.z - safeZone) > (spawnZ - tileOnScreen * tileLength)){
			spawn_tile();
			delete_tile();
		}
	}

	private void spawn_tile(int prefabIndex = -1){
		GameObject tile;

		if(prefabIndex == -1){
			tile = Instantiate(tilePrefabs[random_prefab_index()]) as GameObject;	
		}
		else{
			tile = Instantiate(tilePrefabs[prefabIndex]) as GameObject;	
		}
		
		tile.transform.SetParent(transform);
		tile.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		activeTiles.Add(tile);
	}

	private void delete_tile(){
		Destroy(activeTiles[0]);
		activeTiles.RemoveAt(0);
	}

	private int random_prefab_index(){
		if(tilePrefabs.Length <= 1){
			return 0;
		}

		int randomIndex = lastPrefabIndex;
		while(randomIndex == lastPrefabIndex){
			randomIndex = Random.Range(0, tilePrefabs.Length);
		}

		lastPrefabIndex = randomIndex;
		return randomIndex;
	}
}
