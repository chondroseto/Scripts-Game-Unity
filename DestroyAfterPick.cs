using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterPick : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
		if (other.GetComponents<PlayerController> () == null)
			return;
		if (other.tag == "Player" || other.tag == "Player Attack") {
			Destroy (gameObject);
		}

	}
}
