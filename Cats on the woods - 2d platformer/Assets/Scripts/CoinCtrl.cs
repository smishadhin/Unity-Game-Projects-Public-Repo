using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCtrl : MonoBehaviour {
	
	public enum CoinFX{
		Vanish,
		Fly
	}

	public CoinFX coinFx;
	public float speed;
	public bool startFlying;

	private GameObject coinmeter;

	private void Start(){
		startFlying = false;

		if (coinFx == CoinFX.Fly){
			coinmeter = GameObject.Find("Image_Coin_count");
		}
	}

	private void Update(){
		if (startFlying){
			transform.position = Vector3.Lerp(transform.position, coinmeter.transform.position, speed);

		}
	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Player")){
			
			if (coinFx== CoinFX.Vanish){
				Destroy(gameObject);
			}else if (coinFx == CoinFX.Fly){
				startFlying = true;
			}
		}
	}
}
