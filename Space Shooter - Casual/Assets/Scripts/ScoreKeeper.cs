using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    public static int score;
    private Text text;

    private void Start() {
        text = GetComponent<Text>();
        reset();
    }

    public void Sore(int points) {
        Debug.Log("score");
        score += points;
        text.text = score.ToString();
    }

    public static void reset() {
        score = 0;
    }
}