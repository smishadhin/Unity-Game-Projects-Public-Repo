﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraCtrl : MonoBehaviour{

	public Transform player;

	public float yoffset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update (){
		transform.position = new Vector3(player.position.x,player.position.y+yoffset,transform.position.z);
	}
}
