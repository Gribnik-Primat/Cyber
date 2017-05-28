using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using RootMotion.Demos;

public class AttackRobots : MonoBehaviour {

    public GameObject[] Robots;
   public int n;
   public int r;
    CharacterStatsEnemy chartRob;

	void Start ()
    {
        r = 0;
       // n = Random.Range(0, 16);
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
            if (r <= 4)
            {
                if (chartRob.deadrobots == true)
                {
                    r++;
                    //  n = Random.Range(0, 16);
                    Robots[n].gameObject.GetComponent<EnemyRobotAI>().enabled = true;
                    chartRob.deadrobots = false;
                    
                }
            }
            else
            {
                Application.LoadLevel(4);
            }

        }
    }
}
