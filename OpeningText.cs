using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningText : MonoBehaviour {

	public GameObject noteMoveScene;

	public KeyCode moveScene;

	public Text paragraph;

	public string t;
	private string player;

	public float typeSpeed;

	public AudioSource typingsoundeffect;

	// Use this for initialization
	void Start () {
		player = PlayerPrefs.GetString ("NamaPlayer");
		PlayerPrefs.SetString ("NamaPlayer", player);
		t = "After his parents were gone "+player+" left the village. on the way he found a dimensional crack. then he entered it without hesitation. in dimensions, he saw many monsters. then he tried to get back, but the dimensional cracks disappeared. he was trapped in the world of monsters. ";
		StartCoroutine ("AutoType");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (moveScene) && noteMoveScene.activeSelf) {
			SceneManager.LoadScene ("Level1");
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
