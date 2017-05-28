using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using RootMotion.Demos;

public class AttackRobots : MonoBehaviour {

    public GameObject[] Robots;
    int n;
    int r;
    public CharacterStatsEnemy[] chartRob;
	bool flag_dead;

	void Start ()
	{
		
		flag_dead = false;
        r = 0;
		n = 0;

	}
	
	
	void Update ()
    {
        //n = Random.Range(0, 16);
    }
    void OnTriggerStay(Collider other)
    {
		for(int i = 0;i<Robots.Length;i++) {
			chartRob[i] = Robots [i].GetComponent<CharacterStatsEnemy> ();
		}
        if (other.gameObject.tag == "Player")
        {
            if (r <= 4)
            {
				flag_dead = true;
				for (int i = 0; i < chartRob.Length; i++) {
					if (chartRob [i].deadrobots == false)
						flag_dead = false;
				}
                if (flag_dead == true)
                {
                    r++;
					n += r;
					for (int i = n - r; i < n; i++) {
						Robots [i].gameObject.GetComponent<EnemyRobotAI> ().enabled = true;
						chartRob [i].deadrobots = false;
					}
                    
                }
            }
            else
            {
                Application.LoadLevel(4);
            }

        }
    }
}
