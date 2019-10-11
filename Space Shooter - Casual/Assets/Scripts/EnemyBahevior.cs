using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBahevior : MonoBehaviour {
    public float health = 150f;
    public GameObject projectile;
    private float projectilesped = 10f;
    public float shotspersecond = 0.5f;
    public int scorevalue = 10;

    private ScoreKeeper scoreKeeper;
    public AudioClip fireSound;
    public AudioClip deathsound;
    public ParticleSystem DestructionEffect;


    private void Start() {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    private void Update() {
        float probability = Time.deltaTime * shotspersecond;
        if (Random.value < probability) {
            fire();
        }
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

    void fire() {
        GameObject missile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectilesped);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void die() {
        AudioSource.PlayClipAtPoint(deathsound, transform.position);

        //Instantiate our one-off particle system
        ParticleSystem explosionEffect = Instantiate(DestructionEffect)
            as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        //play it

        explosionEffect.Play();

        //destroy the particle system when its duration is up, right
        //it would play a second time.
        Destroy(explosionEffect.gameObject, explosionEffect.main.duration);
        Destroy(gameObject);

        scoreKeeper.Sore(scorevalue);
    }
}