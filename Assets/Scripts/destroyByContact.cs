using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByContact : MonoBehaviour {
	public int life;
	private int i = 0;

	public int scoreValue;
	private GameController gameController;

	public GameObject explosion;
	public GameObject playerExplosion;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null){
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if(gameController == null){
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) 
    {
		if (other.tag == "Boundary"){
			return;
		}
		
		if(i >= life) {
			Destroy(gameObject);
			Instantiate(explosion, transform.position, transform.rotation);
			gameController.addScore(scoreValue);
		}
		else i++;

		if (other.tag == "Player"){
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		}
		Destroy(other.gameObject);
    } 
}
