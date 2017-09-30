using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Wait{
	public float spawn, start, wave;
}

[System.Serializable]
public class Texts{
	public UnityEngine.UI.Text score, restart, gameOver;
}

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;

	public Wait wait;
	public Texts texts;
		
	private int score; 
	private bool gameOver;
	private bool gameRestart;

	void Start () {
		StartInit();
		UpdateScore();
		StartCoroutine (spawnWaves());	
	}

	void StartInit(){
		score = 0;
		gameOver = false;
		gameRestart = false;
		texts.restart.text = "";
		texts.gameOver.text = "";
	}
	
	void Update(){
		if(gameRestart && Input.GetKeyDown(KeyCode.R)){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
			// Application.LoadLevel(Application.loadedLevel);
		}
	}

	void UpdateScore(){
		texts.score.text = "Score: " + score;
	}

	public void addScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore();
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
			if(gameOver){
				texts.restart.text = "Press 'R' to restart the Game (temp)";
				gameRestart = true;
				break;
			}
		}
	}

	public void GameOver(){
		texts.gameOver.text = "Game Over";
		gameOver = true;
	}
}
