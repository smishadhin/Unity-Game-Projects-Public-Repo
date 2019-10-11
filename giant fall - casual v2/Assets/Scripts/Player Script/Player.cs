using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 8f, maxVelocity = 4f;

    private Rigidbody2D myBody;
    private Animator anim;


    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void FixedUpdate() {
        playerMoveKeyBoard();
    }

    void playerMoveKeyBoard() {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        Vector3 temp = transform.localScale;
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0) {
            if (vel < maxVelocity) {
                forceX = speed;
            }


            temp.x = 1.3f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        } else if (h < 0) {
            if (vel < maxVelocity) {
                forceX = -speed;
            }

            temp.x = -1.3f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        } else {
            anim.SetBool("Walk", false);
        }

        myBody.AddForce(new Vector2(forceX, 0));
    }
}