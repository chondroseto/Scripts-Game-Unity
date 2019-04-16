using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour {

	public GameObject ShopUI;
	public GameObject textTitle;
	public GameObject textWarning;

	public KeyCode buyPotion;
	public KeyCode buySword;
	public KeyCode buyArcher;
	public KeyCode buyArrow;
	public KeyCode closeShop;

	public int healthtoadd;

	public int hargaPotion;
	public int hargaSword;
	public int hargaBow;
	public int hargaArrow;

	public AudioSource buySound;
	public AudioSource ErrorSound;

	// Use this for initialization
	void Start () {
		textTitle.SetActive (true);
		textWarning.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (closeShop)) {
			ShopUI.SetActive (false);
			Time.timeScale = 1f;
		}
		if (Input.GetKeyDown (buyPotion) ) {
			if (InfoPlayerManager.Coins < hargaPotion) {
				ErrorSound.Play ();
				textWarning.SetActive (true);
				textTitle.SetActive (false);
			} else {
				buySound.Play ();
				InfoPlayerManager.PickPotion (healthtoadd);
				InfoPlayerManager.UseCoins (hargaPotion);
				textTitle.SetActive (true);
				textWarning.SetActive (false);
			}
		}
		if (Input.GetKeyDown (buySword) ) {
			if (InfoPlayerManager.Coins < hargaSword) {
				ErrorSound.Play ();
				textWarning.SetActive (true);
				textTitle.SetActive (false);
			} else {
				buySound.Play ();
				InfoPlayerManager.PickSword();
				InfoPlayerManager.UseCoins (hargaSword);
				textTitle.SetActive (true);
				textWarning.SetActive (false);
			}
		}
		if (Input.GetKeyDown (buyArcher) ) {
			if (InfoPlayerManager.Coins < hargaBow) {
				ErrorSound.Play ();
				textWarning.SetActive (true);
				textTitle.SetActive (false);
			} else {
				buySound.Play ();
				InfoPlayerManager.PickBow();
				InfoPlayerManager.UseCoins (hargaBow);
				textTitle.SetActive (true);
				textWarning.SetActive (false);
			}
		}
		if (Input.GetKeyDown (buyArrow)) {
			if (InfoPlayerManager.Coins < hargaArrow) {
				ErrorSound.Play ();
				textWarning.SetActive (true);
				textTitle.SetActive (false);
			} else {
				buySound.Play ();
				InfoPlayerManager.PickArrow ();
				InfoPlayerManager.UseCoins (hargaArrow);
				textTitle.SetActive (true);
				textWarning.SetActive (false);
			}
		}

		
	}
}
