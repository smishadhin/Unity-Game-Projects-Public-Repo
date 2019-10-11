using UnityEngine;
using System.Collections;

public class SamplePlatform : MonoBehaviour 
{
	public float droppingDelay;

	Rigidbody2D rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("PlayerFeet"))
		{
			Invoke("StartDropping", droppingDelay);
		}
	}

	void StartDropping()
	{
		rb.isKinematic = false;
	}

}
