using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;

	public int hazardCount = 10;
	public float spawnWait = 0.5f;
	public float startWait = 2.0f;
	public float waveWait = 3.0f;

	public Text scoreText;
	private int score = 0;

	// Use this for initialization
	void Start () {
		updateScore ();
		StartCoroutine (spawnHazards());
	}

	public void addScore(int newScore){

		score += newScore;
		updateScore ();
	}

	void updateScore(){
		scoreText.text = "Score : " + score;
	}
	
	IEnumerator spawnHazards(){
		yield return new WaitForSeconds (startWait);

		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (
					                       Random.Range (-spawnValues.x, spawnValues.x),
					                       spawnValues.y,
					                       spawnValues.z);

				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait);
		}
	}
}
