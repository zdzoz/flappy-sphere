using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour {

	public GameObject wall;
	static public LinkedList<GameObject> walls = new LinkedList<GameObject>();
	private float spawnRate = 2.0f;

	void Start () {
		InvokeRepeating ("SpawnWall", 0, spawnRate);
	}

	void Update(){
		spawnRate = Random.Range (2.5f, 3.0f);
		if (PlayerController.isGameOver){
			spawnRate = 0.0f;
		}
	}

	void SpawnWall(){
		if (!PlayerController.isGameOver) {
			var newWall = GameObject.Instantiate (wall);
			walls.AddLast (newWall);
			newWall.transform.position = new Vector2 (4.5f, Random.Range (-3f, 3.5f));
		}
	}
}
