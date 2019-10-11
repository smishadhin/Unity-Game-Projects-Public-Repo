using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class HeadCtrl : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Breackable")){
			SFXCtrl.instance.shandleboxbraking(other.gameObject.transform.parent.transform.position);
			gameObject.transform.parent.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			Destroy(other.gameObject.transform.parent.gameObject);
			
		}
	}
}
