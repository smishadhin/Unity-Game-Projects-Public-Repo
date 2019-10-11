using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour{

	public float speed;

	private float offsetX;

	private Material mat;

	public GameObject player;
	private PlayerCtrl playerctrl;
	
	// Use this for initialization
	void Start (){
		mat = GetComponent<Renderer>().material;
		playerctrl = player.GetComponent<PlayerCtrl>();
	}
	
	// Update is called once per frame
	void Update (){
		//offsetX += 0.005f;
		if (!playerctrl.isStuck){
			offsetX += Input.GetAxisRaw("Horizontal") * speed;

			if (playerctrl.leftPressed){
				offsetX -= speed;
			}else if (playerctrl.rightPressed){
				offsetX += speed;
			}
			
			mat.SetTextureOffset("_MainTex",new Vector2(offsetX,0));
			
		
		}
		
		
	}
}
