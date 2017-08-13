using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject treePrefabs;
	public GameObject[] tilePrefabs;

	private Transform playerTransform;
	private float spawnZ = 0.0f;
	private float tileLength = 20.0f;
	private float currentTileLength;
	private int tileOnScreen = 6;
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
			spawn_tree();
		}
	}

	private void spawn_tile(int prefabIndex = -1){
		GameObject tile;
		currentTileLength = 0.0f;

		if(prefabIndex == -1){
			tile = Instantiate(tilePrefabs[random_prefab_index()]) as GameObject;
		}
		else{
			tile = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
		}
		
		tile.transform.SetParent(transform);
		tile.transform.position = Vector3.forward * spawnZ;
		//spawnZ += tileLength;
		activeTiles.Add(tile);


		Transform[] tilesChildren = tile.GetComponentsInChildren<Transform>();
        foreach(Transform child in tilesChildren){
            if(child.gameObject.tag.Contains("Tile")){
                currentTileLength += child.GetComponent<Renderer>().bounds.size.z;
            }
        }
		
		spawnZ += currentTileLength;

	}

	private void delete_tile(){
		Destroy(activeTiles[0]);
		activeTiles.RemoveAt(0);
	}

	private void spawn_tree(){
		GameObject tree = Instantiate(treePrefabs) as GameObject;
		float side = ( 0.5f - Random.Range(0.0f,1.0f) > 0 ) ? 1.0f : -1.0f;
		float size = Random.Range(0.8f,1.5f);

		tree.transform.SetParent(transform);
		tree.transform.position = new Vector3( side * 5.0f, 0.0f, spawnZ + Random.Range(-5.0f, 5.0f) );
		tree.transform.localScale = new Vector3( size, size, size );
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

	public void kill_all_enemy(){
		foreach(GameObject tile in activeTiles){
			Transform[] tilesChildren = tile.GetComponentsInChildren<Transform>();
			foreach(Transform child in tilesChildren){
				if(child.gameObject.tag.Contains("Enemy")){
					Destroy(child.gameObject);
				}
			}
		}
	}
}
