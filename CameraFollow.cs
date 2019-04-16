using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Vector2 vcty;

	public float smoothY;
	public float smoothX;

	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		
	}
	
	void FixedUpdate(){
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref vcty.x, smoothX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref vcty.y, smoothY);

		transform.position = new Vector3 (posX, posY, transform.position.z);
	}
}
