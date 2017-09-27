﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wait{
	public float spawn, start, wave;
}

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;

	public Wait wait;

	void Start () {
		StartCoroutine (spawnWaves());	
	}
	
	IEnumerator spawnWaves() {
		yield return new WaitForSeconds (wait.start);
		while(true){
			for (int i =0; i < hazardCount; i++){
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (wait.spawn);
			}
			yield return new WaitForSeconds (wait.wave);
		}
	}
}
