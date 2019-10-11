using System;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;


    [Tooltip("this is a positive int to speed up of the player")] public int speedBoost;

    public float jumpSpeed;
    private bool  doublejump;
    public bool isGrounded;
    public Transform feet;
    public float feetRadious;
    public LayerMask whatisground;
    public float boxWidth;
    public float boxHeight;
    public float delayfordoublejump;
    public Transform leftbulletspwanposition, rightbulletspwanposition;
    public GameObject leftBullet, rightBullet;
    public bool leftPressed, rightPressed;
    public bool SFXOn;
    public bool canFire , isJumping , isStuck;

    // Use this for initialization
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){

        if (transform.position.y < -3.2){
            DisableCamera();
        }
        //isGrounded = Physics2D.OverlapCircle(feet.position, feetRadious, whatisground);
        isGrounded = Physics2D.OverlapBox(new Vector2(feet.position.x, feet.position.y),
            new Vector2(boxWidth, boxHeight), 360.0f, whatisground);

        float playerSpeed = Input.GetAxisRaw("Horizontal");
        playerSpeed *= speedBoost;
        if (playerSpeed != 0){
            moveHorizontal(playerSpeed);
        } else{
            stopMoving();
        }

        if (Input.GetButtonDown("Jump")){
            jump();
        }
        showFalling();

        if (Input.GetButtonDown("Fire1")){
            fireBullets();
        }

        if (leftPressed){
            moveHorizontal(-speedBoost);
        }

        if (rightPressed){
            moveHorizontal(speedBoost);
        }
    }

    private void OnDrawGizmos(){
        Gizmos.DrawWireCube(feet.position, new Vector3(boxWidth, boxHeight, 0));
    }

    void moveHorizontal(float playerSpeed){
        rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
        if (playerSpeed < 0){
            sr.flipX = true;
        } else if (playerSpeed > 0){
            sr.flipX = false;
        }
        if (!isJumping){
            anim.SetInteger("State", 1);
        }
    }

    void stopMoving(){
        rb.velocity = new Vector2(0, rb.velocity.y);
        if (!isJumping){
            anim.SetInteger("State", 0);
        }
    }

    void jump(){
        if (isGrounded){
            isJumping = true;
            rb.AddForce(new Vector2(0, jumpSpeed));
            anim.SetInteger("State", 2);

            Invoke("enableDoubleJump", delayfordoublejump);
        }
        if (doublejump && !isGrounded){
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpSpeed));
            anim.SetInteger("State", 2);
            doublejump = false;
        }
    }

    void fireBullets(){
        if (canFire){
            if (sr.flipX){
                Instantiate(leftBullet, leftbulletspwanposition.position, Quaternion.identity);
            }
            if (!sr.flipX){
                Instantiate(rightBullet, rightbulletspwanposition.position, Quaternion.identity);
            }
        }
    }

    public void MobileMoveLeft(){
        leftPressed = true;
    }

    public void MobileMoveRight(){
        rightPressed = true;
    }

    public void MobileStop(){
        leftPressed = false;
        rightPressed = false;
        stopMoving();
    }

    public void MobileFireBullets(){
        fireBullets();
    }

    public void MobileJump(){
        jump();
    }

    void enableDoubleJump(){
        doublejump = true;
    }

    void showFalling(){
        if (rb.velocity.y < 0){
            anim.SetInteger("State", 3);
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Ground")){
            
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        switch (other.gameObject.tag){
            case "Coin":
                if (SFXOn){
                    SFXCtrl.instance.showCoinSpark(other.gameObject.transform.position);
                    GameCtrl.instance.updatecoincount();
                }
                break;
            case "Water":
                SFXCtrl.instance.showSplash(other.gameObject.transform.position);
               Debug.Log("drowned");
                break;
            case "Powerup_Bullet":
                canFire = true;
                Vector3 poweruppos = other.gameObject.transform.position;
                Destroy(other.gameObject);
                if (SFXOn)
                    SFXCtrl.instance.showBulletSpark(poweruppos);
                break;
            default:
                break;
        }
    }
    
    void DisableCamera()
    {
        Camera.main.GetComponent<CamraCtrl>().enabled = false;
    }
}