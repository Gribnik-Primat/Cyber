﻿using UnityEngine;
using System.Collections;

public class TriggerSpawn : MonoBehaviour
{

    GameManager gm;
    RotCam rc;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        
		if (other.GetComponent<PlayerHack>())
        {
            
            gm.spawnEnemiesNow = true;
            Destroy(gameObject);

        }
    }
}
