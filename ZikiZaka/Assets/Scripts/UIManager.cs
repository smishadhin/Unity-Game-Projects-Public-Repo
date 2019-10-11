using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour{

	public static UIManager instance;
	
	public GameObject titlePanel;
	public GameObject gameOverPanel;
	public GameObject taptext;

	public Text score;
	public Text Heighscore1;
	public Text Heighscore2;
	public Text currentScore;


	private void Awake(){
		if (instance==null){
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		Heighscore1.text ="HEIGH SCORE : "+ PlayerPrefs.GetInt("heighScore").ToString();
		
	}
	
	// Update is called once per frame
	void Update (){
		currentScore.text ="SCORE : "+ ScoreManager.instance.score.ToString();
	}

	public void GameStart(){
		taptext.SetActive(false);
		titlePanel.GetComponent<Animator>().Play("panelUp");
	}

	public void GameOver(){
		score.text ="SCORE : " + PlayerPrefs.GetInt("score").ToString();
		Heighscore2.text ="HEIGH SCORE : "+ PlayerPrefs.GetInt("heighScore").ToString();
		gameOverPanel.SetActive(true);
		
	}

	public void reset(){
		SceneManager.LoadScene(0);
	}

	public void quit(){
		Application.Quit();
	}
}
