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
        Rob = GameObject.FindGameObjectsWithTag("Robot");
        Ene = GameObject.FindGameObjectsWithTag("Enemy");
    }
	
	
	void Update ()
    {
		
	}
    void OntriggerStay(Collider other)
    {
        if(other.gameObject.tag=="Enemy" || other.gameObject.tag == "Robot")
        {
            foreach (GameObject rob in Rob)
                rob.GetComponentInParent<CharacterStatsEnemy>().healthE = 0;

            foreach (GameObject ene in Ene)
                ene.GetComponentInParent<CharacterStatsEnemy>().healthE = 0;

        }
    }
}
