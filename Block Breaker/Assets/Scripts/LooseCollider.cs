using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseCollider : MonoBehaviour {
    private LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D trigger) {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("Loose Screen");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        print("collision");
    }
}