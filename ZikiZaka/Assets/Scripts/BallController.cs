using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour{

	public GameObject particle;
	
	[SerializeField]
	private float speed;

	private bool started;
	private bool gameOver;

	private Rigidbody rb;

	public AudioClip moveaudio;
	public AudioClip diamondAudio;
	
	private void Awake(){
		rb = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start (){
		started = false;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!started){
			if (Input.GetMouseButtonDown(0)){
				rb.velocity = new Vector3(speed,0,0);
				started = true;
				GameManager.instance.startGame();
			}
		}

		if (!Physics.Raycast(transform.position, Vector3.down, 1f)){
			gameOver = true;
			rb.velocity = new Vector3(0,-25f,0);

			Camera.main.GetComponent<Camerafollow>().gameOver = true;
			GameManager.instance.gameOVer();
		}
		
		
		if (Input.GetMouseButtonDown(0) && !gameOver){
			SwitchDirection();
		}
	}


	private void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Diamond")){
			GameObject part = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;
			ScoreManager.instance.score += 10;
			AudioSource.PlayClipAtPoint(diamondAudio,other.transform.position);
			Destroy(other.gameObject);
			Destroy(part,1f);
		}
	}


	void SwitchDirection(){
		if (rb.velocity.z>0){
			rb.velocity = new Vector3(speed,0,0);
		}else if (rb.velocity.x > 0){
			rb.velocity = new Vector3(0,0,speed);
		}
		AudioSource.PlayClipAtPoint(moveaudio,transform.position);
	}
}
