﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestryWithdelay : MonoBehaviour{

	public float delay;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject,delay);
	}
}
