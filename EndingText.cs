using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingText : MonoBehaviour {

	public GameObject noteMoveScene;

	public KeyCode moveScene;

	public Text paragraph;

	public string t;
	private string player;

	public float typeSpeed;

	public AudioSource typingsoundeffect;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
		player = PlayerPrefs.GetString ("NamaPlayer");
		PlayerPrefs.SetString ("NamaPlayer", player);
		t = "After defeating many monsters, "+player+" realizes that not all monsters can open the door of dimensions to return to their world. Only monsters that have great power can open the door of dimensions. His adventures in the world of monsters still continue.";
		StartCoroutine ("AutoType");
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (moveScene) && noteMoveScene.activeSelf) {
			SceneManager.LoadScene ("MainMenu");
			noteMoveScene.SetActive (false);
		}

	}

	IEnumerator AutoType(){
		yield return new WaitForSeconds (1f);
		int letter = 0;
		paragraph.text = "";
		typingsoundeffect.Play ();
		while (letter < t.Length) {
			paragraph.text += t[letter];
			letter += 1;
			yield return new WaitForSeconds (typeSpeed);
		}
		typingsoundeffect.Stop ();
		noteMoveScene.SetActive (true);
	}
}
