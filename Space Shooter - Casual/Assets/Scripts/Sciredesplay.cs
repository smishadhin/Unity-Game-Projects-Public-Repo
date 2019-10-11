using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sciredesplay : MonoBehaviour {
    void Start() {
        Text sc = GetComponent<Text>();
        sc.text = ScoreKeeper.score.ToString();
        ScoreKeeper.reset();
    }

    // Update is called once per frame
    void Update() {
    }
}