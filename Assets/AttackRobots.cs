using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using RootMotion.Demos;

public class AttackRobots : MonoBehaviour {

    public GameObject[] Robots;
    int n;
    CharacterStatsEnemy chartRob;

	void Start ()
    {
       n= Random.Range(0, 16);
       Robots = GameObject.FindGameObjectsWithTag("Robot");
        chartRob = GameObject.FindGameObjectWithTag("Robot").GetComponentInParent<CharacterStatsEnemy>();
	}
	
	
	void Update ()
    {
        n = Random.Range(0, 16);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (chartRob.deadrobots == true)
            {
                
                Robots[n].gameObject.GetComponent<EnemyRobotAI>().enabled = true;
                chartRob.deadrobots = false;
            }
        }
    }
}
