using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_robots : MonoBehaviour {
	int i = 0;//с какого робота начинаем
	int k = 1;//кол-во роботов за раунд
	int j = 0;//позиция роботов с прошлого рундаж
	int m = 0; //кол-во роботов с прошлого раунла
	GameObject[] robots;
	bool flag_first = false;
	// Use this for initialization
	void Start () {
		robots = GameObject.FindGameObjectsWithTag ("Robot");
		for (int j = 1; j < robots.Length; j++)
			robots [j].gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (robots [i].GetComponent<CharacterStatsEnemy> ().healthE <= 0 ) {
			i++;
			robots [i].gameObject.SetActive (true);
		} 			
	}
}
