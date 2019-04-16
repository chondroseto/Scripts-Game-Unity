using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour {

	private string namePlayer;
	public GameObject buttonStart;
	public GameObject textField;
	public Text playerName;

	public AudioSource ClickSound;

	public void moveScene(){
		ClickSound.Play ();
		SceneManager.LoadScene ("OpeningStory");
		namePlayer = playerName.text;
		PlayerPrefs.SetString ("NamaPlayer", namePlayer);
		buttonStart.SetActive (true);
		textField.SetActive (false);
	}

	public void showTextField(){
		ClickSound.Play ();
		buttonStart.SetActive (false);
		textField.SetActive (true);
	}
		

	public void QuitGame(){
	 	ClickSound.Play ();
		Application.Quit();
	}
}
