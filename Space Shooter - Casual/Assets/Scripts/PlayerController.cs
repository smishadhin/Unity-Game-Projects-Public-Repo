using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    float health = 250;
    private float speed = 15f;
    public float padding = 1f;
    public GameObject projectile;
    float projectileSpeed = 4f;
    float firingRate = .5f;

    private float xMin = -5f;
    private float Xmax = 5f;
    public AudioClip fireSound;
    public ParticleSystem DestructionEffect;


    // Use this for initialization
    void Start() {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftmost.x + padding;
        Xmax = rightmost.x - padding;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            InvokeRepeating("Fire", -.5f, firingRate);
            
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            CancelInvoke("Fire");
            
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += Vector3.left * speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        float newX = Mathf.Clamp(transform.position.x, xMin, Xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    void Fire() {
        GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();

        if (missile) {
            health -= missile.getDamage();
            missile.Hit();
            if (health <= 0) {
                die();
            }
        }
    }

    void die() {
        
        Destroy(gameObject);
       
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        man.LoadLevel("Win Screen");
    }

    void deadanim() {
        //Instantiate our one-off particle system
        ParticleSystem explosionEffect = Instantiate(DestructionEffect)
            as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        //play it

        explosionEffect.Play();

        //destroy the particle system when its duration is up, right
        //it would play a second time.
        Destroy(explosionEffect.gameObject, explosionEffect.main.duration);
    }
}