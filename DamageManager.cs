using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageManager : MonoBehaviour {

	public int damage;

	public Text targetName;
	public Text targetHP;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "BatLight") {
			InfoEnemyManager.HealthBatLight (damage);
			targetName.text = InfoEnemyManager.NameBatLight;
			targetHP.text = ""+InfoEnemyManager.HPBatLight;
		}
		if (other.tag == "BatDark") {
			InfoEnemyManager.HealthBatDark (damage);
			targetName.text = InfoEnemyManager.NameBatDark;
			targetHP.text = ""+InfoEnemyManager.HPBatDark;
		}
		if (other.tag == "Ghost") {
			InfoEnemyManager.HealthGhost (damage);
			targetName.text = InfoEnemyManager.NameGhost;
			targetHP.text = ""+InfoEnemyManager.HPGhost;
		}
		if (other.tag == "Keong") {
			InfoEnemyManager.HealthKeong (damage);
			targetName.text = InfoEnemyManager.NameKeong;
			targetHP.text = ""+InfoEnemyManager.HPKeong;
		}
		if (other.tag == "Skeleton") {
			InfoEnemyManager.HealthSkeleton (damage);
			targetName.text = InfoEnemyManager.NameSkeleton;
			targetHP.text = ""+InfoEnemyManager.HPSkeleton;
		}
		if (other.tag == "Skeleton Boss") {
			InfoEnemyManager.HealthSkeletonBoss (damage);
			targetName.text = InfoEnemyManager.NameSkeletonBoss;
			targetHP.text = "" + InfoEnemyManager.HPSkeletonBoss;
		}
	}
}
