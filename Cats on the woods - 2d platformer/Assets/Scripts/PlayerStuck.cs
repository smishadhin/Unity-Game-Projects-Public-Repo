using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuck : MonoBehaviour{

	public GameObject player;

	private PlayerCtrl playerCtrl;
	// Use this for initialization
	void Start (){
		playerCtrl = player.GetComponent<PlayerCtrl>();
	}

	private void OnTriggerEnter2D(Collider2D other){
		playerCtrl.isStuck = true;
	}

	private void OnTriggerExit2D(Collider2D other){
		playerCtrl.isStuck = false;
	}
}
