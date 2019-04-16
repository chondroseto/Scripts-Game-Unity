using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPlayerManager : MonoBehaviour {

	public Text CoinsText;
	public Text ArrowText;
	public Text SwordText;
	public Text BowText;
	public Text HPText;

	public static int HP;
	public static int Arrow;
	public static int Sword;
	public static int Bow;
	public static int Coins;
	public static int Life;

	public GameObject life1;
	public GameObject life2;
	public GameObject life3;
	public GameObject life4;
	public GameObject life5;
	public GameObject life6;
	public GameObject life7;
	public GameObject life8;


	// Use this for initialization
	void Start () {
		HP = 100;
		Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (HP <= 0 && Life > 0) {
			HP = 100;
			Life = Life - 1;
		} else if (HP > 100) {
			Life = Life + 1;
			HP = HP - 100;
		} else if (HP < 0 && Life == 0) {
			HP = 0;
		}
			
		if (Bow > 100) {
			Bow = 100;
		}
		if (Sword > 100) {
			Sword = 100;
		}
		if (Life  == 0){
			life1.SetActive (false);
			life2.SetActive (false);
			life3.SetActive (false);
			life4.SetActive (false);
			life5.SetActive (false);
			life6.SetActive (false);
			life7.SetActive (false);
			life8.SetActive (false);
		} else if (Life  == 1) {
			life1.SetActive (true);
			life2.SetActive (false);
			life3.SetActive (false);
			life4.SetActive (false);
			life5.SetActive (false);
			life6.SetActive (false);
			life7.SetActive (false);
			life8.SetActive (false);
		}else if (Life  == 2) {
			life1.SetActive (true);
			life2.SetActive (true);
			life3.SetActive (false);
			life4.SetActive (false);
			life5.SetActive (false);
			life6.SetActive (false);
			life7.SetActive (false);
			life8.SetActive (false);
		}else if (Life  == 3) {
			life1.SetActive (true);
			life2.SetActive (true);
			life3.SetActive (true);
			life4.SetActive (false);
			life5.SetActive (false);
			life6.SetActive (false);
			life7.SetActive (false);
			life8.SetActive (false);
		}else if (Life  == 4) {
			life1.SetActive (true);
			life2.SetActive (true);
			life3.SetActive (true);
			life4.SetActive (true);
			life5.SetActive (false);
			life6.SetActive (false);
			life7.SetActive (false);
			life8.SetActive (false);
		}else if (Life == 5) {
			life1.SetActive (true);
			life2.SetActive (true);
			life3.SetActive (true);
			life4.SetActive (true);
			life5.SetActive (true);
			life6.SetActive (false);
			life7.SetActive (false);
			life8.SetActive (false);
		}else if (Life  == 6) {
			life1.SetActive (true);
			life2.SetActive (true);
			life3.SetActive (true);
			life4.SetActive (true);
			life5.SetActive (true);
			life6.SetActive (true);
			life7.SetActive (false);
			life8.SetActive (false);
		}else if (Life  == 7) {
			life1.SetActive (true);
			life2.SetActive (true);
			life3.SetActive (true);
			life4.SetActive (true);
			life5.SetActive (true);
			life6.SetActive (true);
			life7.SetActive (true);
			life8.SetActive (false);
		}else if (Life >= 8) {
			life1.SetActive (true);
			life2.SetActive (true);
			life3.SetActive (true);
			life4.SetActive (true);
			life5.SetActive (true);
			life6.SetActive (true);
			life7.SetActive (true);
			life8.SetActive (true);
		}

		CoinsText.text = "" + Coins;
		ArrowText.text = "" + Arrow;
		SwordText.text = "" + Sword;
		BowText.text = "" + Bow;
		HPText.text = "" + HP;

	}

	public static void AttackPlayer(int DamageEnemy){
		HP -= DamageEnemy;
	}
	public static void PickPotion(int PotionHeal){
		HP += PotionHeal;
	}
	public static void UseCoins(int HowMuch){
		Coins -= HowMuch;
	}
	public static void PickCoins(int Get){
		Coins += Get;
	}
	public static void UseArrow(){
		Arrow -= 1;
	}
	public static void PickArrow(){
		Arrow += 1;
	}
	public static void UseSword(){
		Sword -= 1;
	}
	public static void PickSword(){
		Sword += 100;
	}
	public static void UseBow(){
		Bow -= 1;
	}
	public static void PickBow(){
		Bow += 100;
	}
}
