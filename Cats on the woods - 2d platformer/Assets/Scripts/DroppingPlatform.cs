using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingPlatform : MonoBehaviour{
	private Rigidbody2D rb;

	public float droppingdelay;
	// Use this for initialization
	void Start (){
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("PlayerFeet")){
			Invoke("startDropping",droppingdelay);
		}
	}

	void startDropping(){
		rb.isKinematic = false;
	}
}
