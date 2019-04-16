using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject stageClear;
	public GameObject UIshop;
	public GameObject DeathUI;
	public GameObject stageClearUI;

	public KeyCode Pause;
	public KeyCode nextStage;

	public bool isPaused;
	public GameObject PauseUI;

	public AudioSource backSound;
	public AudioSource stageClearSound;

	private int level=1;
	//private float timeScale=1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (InfoEnemyManager.HPBatDark <=0 && InfoEnemyManager.HPBatLight<=0 && InfoEnemyManager.HPGhost<=0 && InfoEnemyManager.HPKeong<=0 && InfoEnemyManager.HPSkeleton<=0) {
			stageClearUI.SetActive (true);
		}
		if (InfoEnemyManager.HPSkeletonBoss <= 0) {
			stageClearUI.SetActive (true);
		}
		/*
		if (BossLifeManager.bossLife == 0 && BossHealthManager.healthBoss == 0) {
			stageClear.SetActive (true);
			Time.timeScale = 0f;
		}*/
		if (DeathUI.activeSelf) {
			//backSound.Stop ();
		} else {
			if (UIshop.activeSelf) {
				
			} else {
				if (stageClearUI.activeSelf) {
					//stageClearSound.Play ();
					//backSound.Stop ();
					if (Input.GetKeyDown (nextStage)) {
						if (level==1) {
							//Debug.Log ("level1");
							InfoEnemyManager.HPBatDark=100;
							InfoEnemyManager.HPBatLight=100;
							InfoEnemyManager.HPGhost=100;
							InfoEnemyManager.HPKeong=100;
							InfoEnemyManager.HPSkeleton=100;	
							//PlayerPrefs.SetFloat ("TimeScale",timeScale);
							level+=1;
							SceneManager.LoadScene ("Level2");
						} else if (level==2) {
							//Debug.Log ("level2");
							SceneManager.LoadScene("EndingStory");
							level=1;
						}

					}
					Time.timeScale = 0f;
				} else {
						if (PauseUI.activeSelf) {
							if (Input.GetKeyDown (Pause)) {
								PauseUI.SetActive (false);
								Time.timeScale = 1f;
							}
						} else {
							if (Input.GetKeyDown (Pause)) {
								PauseUI.SetActive (true);
								Time.timeScale = 0f;
							}
						}
				}
				
			}
		}
	}
		
	public void backtoAwal(){
		SceneManager.LoadScene ("MainMenu");
	}
}
