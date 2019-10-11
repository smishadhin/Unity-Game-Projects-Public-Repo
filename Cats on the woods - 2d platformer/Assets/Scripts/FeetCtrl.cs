using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCtrl : MonoBehaviour{
	public Transform dustpos;
	private PlayerCtrl playerCtrl;
	public GameObject player;

	private void Start(){
		playerCtrl = gameObject.transform.parent.gameObject.GetComponent<PlayerCtrl>();
	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Ground")){
			SFXCtrl.instance.showlandingdust(dustpos.position);
			playerCtrl.isJumping = false;
		}
		
		if (other.gameObject.CompareTag("Platform")){
			SFXCtrl.instance.showlandingdust(dustpos.position);
			playerCtrl.isJumping = false;
			player.transform.parent = other.gameObject.transform;
		}
	}

	private void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag("Platform")){
			player.transform.parent = null;
		}
	}
}
