using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour {

	public float moveSpeed;
	public Transform player;
	public Transform boss;

	public Transform playerCheckPoint;
	public float playerCheckRadius;
	public LayerMask whatIsPlayer;

	public bool Attack;

	private Rigidbody2D theRB;

	public int BodyDamage;

	private Animator anim;

	public float hsl;

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

		if (boss.position.x < player.position.x) {
			hsl = player.position.x - boss.position.x;
		} else if (boss.position.x > player.position.x){
			hsl = boss.position.x - player.position.x ;
		}
		if (hsl < 2) {
			Attack = true;
		} else {
			Attack = false;
		}
		if (Attack==true) {
			anim.SetBool ("Attack",Attack);
		} else {

			if (boss.position.x > player.position.x) {
				theRB.velocity = new Vector2 (-moveSpeed, theRB.velocity.y);
			} 
			if (boss.position.x < player.position.x) {
				theRB.velocity = new Vector2 (moveSpeed, theRB.velocity.y);
			}
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
		if (other.tag == "Player") {
			InfoPlayerManager.AttackPlayer (BodyDamage);

		}
	}

}
