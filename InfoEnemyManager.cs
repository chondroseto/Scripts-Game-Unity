using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoEnemyManager : MonoBehaviour {

	public static int HPBatLight=100;
	public static int HPBatDark=100;
	public static int HPGhost=100;
	public static int HPKeong=100;
	public static int HPSkeleton=100;
	public static int HPSkeletonBoss=3000;

	public static string NameBatLight="Bat Light";
	public static string NameBatDark="Bat Dark";
	public static string NameGhost="Ghost";
	public static string NameKeong="Keong";
	public static string NameSkeleton="Skeleton";
	public static string NameSkeletonBoss="White Axe Skeleton";

	public GameObject BatLight;
	public GameObject BatDark;
	public GameObject Ghost;
	public GameObject Keong;
	public GameObject Skeleton;
	public GameObject SkeletonBoss;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (HPBatDark <= 0 ) {
			HPBatDark = 0;
			Destroy (BatDark);
		}
		if (HPBatLight<=0 ){
			HPBatLight = 0;
			Destroy (BatLight);
		}
		if (HPGhost <= 0) {
			HPGhost = 0;
			Destroy (Ghost);
		}
		if(HPKeong<=0 ){
			HPKeong = 0;
			Destroy (Keong);
		}
		if(HPSkeleton<=0){
			HPSkeleton = 0;
			Destroy(Skeleton);
		}
		if (HPSkeletonBoss <= 0) {
			HPSkeletonBoss = 0;
			Destroy (SkeletonBoss);
		}


	}
	public static void HealthBatDark(int DamagePlayer){
		HPBatDark -= DamagePlayer;
	}

	public static void HealthBatLight(int DamagePlayer){
		HPBatLight -= DamagePlayer;
	}

	public static void HealthGhost(int DamagePlayer){
		HPGhost -= DamagePlayer;
	}
	public static void HealthKeong(int DamagePlayer){
		HPKeong -= DamagePlayer;
	}
	public static void HealthSkeleton(int DamagePlayer){
		HPSkeleton -= DamagePlayer;
	}
	public static void HealthSkeletonBoss(int DamagePlayer){
		HPSkeletonBoss -= DamagePlayer;
	}
}
