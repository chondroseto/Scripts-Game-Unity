using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelor : MonoBehaviour {

	public float arrowSpeed;
	
	private Rigidbody2D theRB;
	
	public GameObject arrowEffect;

	public AudioSource hitSound;
	// Use this for initialization
	void Start () {
		
		theRB = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		theRB.velocity = new Vector2 (transform.localRotation.z, -135);
		theRB.velocity = new Vector2(arrowSpeed * transform.localScale.x,0);
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			hitSound.Play ();
		}
		Instantiate(arrowEffect,transform.position,transform.rotation);

		Destroy (gameObject);

	}
}
