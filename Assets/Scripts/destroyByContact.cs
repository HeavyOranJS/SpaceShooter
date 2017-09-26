using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByContact : MonoBehaviour {
	public int life;
	private int i = 0;
	
	public GameObject explosion;
	public GameObject playerExplosion;
	void OnTriggerEnter(Collider other) 
    {
		if (other.tag == "Boundary"){
			return;
		}
		
		if(i >= life) {
			Destroy(gameObject);
			Instantiate(explosion, transform.position, transform.rotation);
		}
		else i++;

		if (other.tag == "Player"){
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		}
		Destroy(other.gameObject);
    } 
}
