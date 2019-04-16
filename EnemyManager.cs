using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

	private PlayerController player;
	public int BodyDamage;
	//public int health;

	private Rigidbody2D theRB;

	public float moveSpeed;

	public bool batasKanan;
	public bool batasKiri;

	public GameObject targetUI;

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (batasKanan==true) {
			theRB.velocity = new Vector2 (-moveSpeed, theRB.velocity.y);
		} 
		if (batasKiri==true) {
			theRB.velocity = new Vector2 (moveSpeed, theRB.velocity.y);
		}

		if(theRB.velocity.x<0)
		{
			transform.localScale = new Vector3(-1,1,1);

		} else if (theRB.velocity.x>0)
		{
			transform.localScale = new Vector3(1,1,1);	
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player Attack") {
			targetUI.SetActive (true);
		}
		if (other.tag == "Player") {
			InfoPlayerManager.AttackPlayer (BodyDamage);
			StartCoroutine (player.knockback(0.01f,player.transform.position));
		}
		if (other.tag == "Batas Kanan") {
			batasKanan = true;
			batasKiri = false;
		}
		if (other.tag == "Batas Kiri") {
			batasKanan = false;
			batasKiri = true;
		}
	}
}
