using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour {
public GameObject barrierPrefab;
public int barrierQuantity;
public float distanceBetweenBarriers;
Vector3 spawnerPos;
Vector3 barrierPos;
Quaternion barrierRot;

	void Start () {
		//Setting barrierpos to spawner's initial position
		barrierPos = this.transform.position;
		spawnerPos = this.transform.position;
		//Loop through the array to spawn the barriers.
		for(int i = 0; i <= barrierQuantity; i++){
			barrierPos.x += distanceBetweenBarriers;
			//Spawning barrier
			Instantiate(barrierPrefab,barrierPos, barrierRot);
		}

		spawnerPos.x -= distanceBetweenBarriers; 
	}
	

	void Update () {
		
	}
}
