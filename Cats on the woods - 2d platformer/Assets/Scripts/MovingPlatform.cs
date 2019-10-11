using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour{

	public Transform pos1, pos2, startpos;
	public float speed;
	private Vector3 nextpos;
	
	// Use this for initialization
	void Start (){
		nextpos = startpos.position;
	}
	
	// Update is called once per frame
	void Update (){
		if (transform.position == pos1.position){
			nextpos = pos2.position;
		}
		if (transform.position == pos2.position){
			nextpos = pos1.position;
		}
		transform.position = Vector3.MoveTowards(transform.position, nextpos, speed * Time.deltaTime);
	}

	private void OnDrawGizmos(){
		Gizmos.DrawLine(pos1.position, pos2.position);
	}
}
