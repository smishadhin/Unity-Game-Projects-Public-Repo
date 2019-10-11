using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour {
    public int maxHit;
    private int timeHit;

    private LevelManager levelManager;

    // Use this for initialization
    void Start() {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timeHit = 0;
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnCollisionEnter2D(Collision2D other) {
        timeHit++;
        if (maxHit == timeHit) {
            Destroy(gameObject);
        }
    }

    void SimulateWin() {
        levelManager.LoadNextLevel();
    }
}