using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	
	public KeyCode left;
	public KeyCode right;
	public KeyCode jump;
	public KeyCode handAttack;
	public KeyCode arrowAttack;
	public KeyCode swordAttack;
	public KeyCode interactNPC;

	private Rigidbody2D theRB;
	
	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	public Transform npcCheckPoint;
	public float npcCheckRadius;
	public LayerMask whatIsNpc;

	public bool isNPC;
	public bool isGrounded;
	public static bool directionHurtka;
	public static bool directionHurtki;

	private Animator anim;

	public GameObject arrowShoot;
	public Transform throwPoint;

	public GameObject UIShop;
	public GameObject DeathEffect;

	public int pickCoin;
	public int lowHeal;
	public int mediumHeal;
	public int superHeal;

	public AudioSource hurtSound;
	public AudioSource coinPickSound;
	public AudioSource itemPickSound;
	public AudioSource arrowSound;
	public AudioSource slashSound;
	public AudioSource handSound;
	public AudioSource jumpSound;
	public AudioSource deathSound;
	public AudioSource backSound;

	
	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		directionHurtka = false;
		directionHurtki = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		isNPC = Physics2D.OverlapCircle(npcCheckPoint.position,npcCheckRadius,whatIsNpc);
	 	isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position,groundCheckRadius,whatIsGround);
		if (InfoPlayerManager.HP == 0 && InfoPlayerManager.Life == 0) {
			backSound.Stop ();
			//deathSound.Play ();
			anim.SetBool ("Death",true);
			DeathEffect.SetActive (true);
		}else {
			if (Input.GetKey (left)) {
				theRB.velocity = new Vector2 (-moveSpeed, theRB.velocity.y);

			} else if (Input.GetKey (right)) {
				theRB.velocity = new Vector2 (moveSpeed, theRB.velocity.y);

			} else {
				theRB.velocity = new Vector2 (0, theRB.velocity.y);
			}
		
			if (Input.GetKeyDown (jump) && isGrounded) {
				jumpSound.Play ();
				theRB.velocity = new Vector2 (theRB.velocity.x, jumpForce);
			}
			if (Input.GetKeyDown(interactNPC) && isNPC) {
				UIShop.SetActive (true);
				Time.timeScale = 0f;
			}
				
			if (Input.GetKeyDown (handAttack)) {
				//handSound.Play ();
				anim.SetTrigger ("HandAttack");
			}

			if (InfoPlayerManager.Arrow>0 && InfoPlayerManager.Bow>0) {
				if(Input.GetKeyDown(arrowAttack)){
					arrowSound.Play ();
					InfoPlayerManager.UseArrow ();
					InfoPlayerManager.UseBow ();
					anim.SetTrigger("ArcherAttack");
					GameObject arrowClone = (GameObject)Instantiate(arrowShoot,throwPoint.position,throwPoint.rotation);
					arrowClone.transform.localScale = transform.localScale;

				}
			}
			if (InfoPlayerManager.Sword>0) {
				if(Input.GetKeyDown(swordAttack)){
					slashSound.Play ();
					anim.SetTrigger("SwordAttack");
					InfoPlayerManager.UseSword();
				}
			}
		}
		
		if(theRB.velocity.x<0)
		{
			transform.localScale = new Vector3(-1,1,1);
			
		} else if (theRB.velocity.x>0)
		{
			transform.localScale = new Vector3(1,1,1);	
		}
			
		anim.SetFloat("Speed",Mathf.Abs(theRB.velocity.x));
		anim.SetBool("Grounded",isGrounded);
		
	}
	public IEnumerator knockback(float knockdur,Vector2 knockbackdir){
		float timer = 0;
		while (knockdur > timer) {
			timer += Time.deltaTime;
				theRB.AddForce (new Vector2 (knockbackdir.x * -100, transform.position.y));
		}
		yield return 0;

	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Fall") {
			DeathEffect.SetActive (true);
			deathSound.Play ();
				Time.timeScale = 0f;
			}
		if (other.tag == "Enemy") {
			hurtSound.Play ();
			anim.SetTrigger ("Hurt");
		}
			
			if (other.tag == "Coin") {
				coinPickSound.Play ();
				InfoPlayerManager.PickCoins (pickCoin);
			}
			if (other.tag == "Arrow") {
				itemPickSound.Play ();
				InfoPlayerManager.PickArrow ();
			}
			if (other.tag == "Bow") {
				itemPickSound.Play();
				InfoPlayerManager.PickBow ();
			}
			if (other.tag == "Sword") {
				itemPickSound.Play ();
				InfoPlayerManager.PickSword ();
			}
			if (other.tag == "Small Potion") {
				itemPickSound.Play ();
				InfoPlayerManager.PickPotion (lowHeal);
			}
			if (other.tag == "Medium Potion") {
				itemPickSound.Play ();
				InfoPlayerManager.PickPotion (mediumHeal);
			}
			if (other.tag == "High Potion") {
				itemPickSound.Play ();
				InfoPlayerManager.PickPotion (superHeal);
			}
			
		}
}
