using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    CharacterStatsPlayer stats;
    Biostim bio;
   
	void Start ()
    {
        
		bio = GetComponent<Biostim>();
        stats = GetComponentInChildren<CharacterStatsPlayer>();
	}
	
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (bio.biostim > 0 && stats.healthP < 100f)
            {
                bio.biostim -= 10f * Time.deltaTime;
                stats.healthP += 7f * Time.deltaTime;
            }
        }

	}
}
