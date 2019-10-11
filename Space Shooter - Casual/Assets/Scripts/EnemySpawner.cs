using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;

    public float width = 10f;
    public float height = 5f;
    public float speed = 5f;
    public float spwanDelay = 0.5f;

    private bool movingRight = true;
    private float xmax;
    private float xmin;

    // Use this for initialization
    void Start() {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmin = leftBoundary.x;
        xmax = rightBoundary.x;

        spwanEnemy();
        spwanUntillFull();
    }

    void spwanUntillFull() {
        Transform freeposition = nextfreeposition();
        if (freeposition) {
            GameObject enemy =
                Instantiate(enemyPrefab, freeposition.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freeposition;
        }
        if (nextfreeposition()) {
            Invoke("spwanUntillFull", spwanDelay);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    // Update is called once per frame
    void Update() {
        if (movingRight) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        } else {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        float rightEdgeOfFormation = transform.position.x + (width / 2);
        float leftEdgeOfFrormation = transform.position.x - (width / 2);
        if (leftEdgeOfFrormation < xmin) {
            movingRight = true;
        } else if (rightEdgeOfFormation > xmax) {
            movingRight = false;
        }

        if (allMembersDead()) {
            spwanUntillFull();
        }
    }

    void spwanEnemy() {
        foreach (Transform child in transform) {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    Transform nextfreeposition() {
        foreach (Transform chidpoisitionGameobject in transform) {
            if (chidpoisitionGameobject.childCount == 0) {
                return chidpoisitionGameobject;
            }
        }
        return null;
    }

    bool allMembersDead() {
        foreach (Transform chidpoisitionGameobject in transform) {
            if (chidpoisitionGameobject.childCount > 0) {
                return false;
            }
        }
        return true;
    }
}