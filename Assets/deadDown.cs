using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using RootMotion.Demos;

public class deadDown : MonoBehaviour {
    CharacterStatsEnemy charts;
    GameObject[] Rob;
    GameObject[] Ene;
	
	void Start ()
    {
		Rob = GameObject.FindGameObjectsWithTag ("Robot");
		Ene = GameObject.FindGameObjectsWithTag ("Enemy");
    }
	
	
	void Update ()
    {
		foreach (GameObject robot in Rob)
			if (robot.transform.position.y <= -5)
				robot.GetComponent<CharacterStatsEnemy> ().healthE = 0;
		foreach (GameObject enemy in Ene)
			if (enemy.transform.position.y <= -5)
				enemy.GetComponent<CharacterStatsEnemy> ().healthE = 0;
	}
   
}
