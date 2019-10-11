using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private Rigidbody2D rigidbody2D;
    private Vector3 paddletoBallVector;

    private bool hasStarted = false;


    // Use this for initialization
    void Start() {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddletoBallVector = this.transform.position - paddle.transform.position;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (!hasStarted) {
            //lock the ball relateve to paddle
            this.transform.position = paddle.transform.position + paddletoBallVector;

            //wait for a click to launch the ball
            if (Input.GetMouseButtonDown(0)) {
                print("clicker");
                hasStarted = true;
                this.rigidbody2D.velocity = new Vector2(2f, 10f);
            }
        }
    }
}