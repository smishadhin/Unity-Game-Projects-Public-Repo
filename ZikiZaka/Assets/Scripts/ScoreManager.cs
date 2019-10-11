using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour{

	public static ScoreManager instance;

	public int score;
	public int heighScore;

	private void Awake(){
		if (instance == null){
			instance = this;
		}
	}

	// Use this for initialization
	void Start (){
		score = 0;
		PlayerPrefs.SetInt("score",score);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void incrementScore(){
		score += 1;
	}

	public void starScore(){
		InvokeRepeating("incrementScore",0.1f,0.5f);
	}

	public void stopScore(){
		CancelInvoke("incrementScore");
		PlayerPrefs.SetInt("score",score);

		if (PlayerPrefs.HasKey("heighScore")){
			if (score > PlayerPrefs.GetInt("heighScore")){
				PlayerPrefs.SetInt("heighScore",score);
			}
		} else{
			PlayerPrefs.SetInt("heighScore",score);
		}
	}
}
