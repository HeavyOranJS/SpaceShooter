using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomRotator : MonoBehaviour {
	public float tumble;
	// Use this for initialization
	void Start () {
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.angularVelocity = Random.onUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
