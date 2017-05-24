using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    CharacterStatsPlayer stats;
    Biostim bio;
    Animator anim;
	void Start ()
    {
      anim= GetComponentInChildren<Animator>();
		bio = GetComponent<Biostim>();
        stats = GetComponentInChildren<CharacterStatsPlayer>();
	}
	
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            if (bio.biostim > 0 && stats.healthP < 100f)
            {
                bio.biostim -= 10f * Time.deltaTime;
                stats.healthP += 7f * Time.deltaTime;
                anim.SetBool("Health", true);
            }
        }
        else
        {
            anim.SetBool("Health", false);
        }

	}
}
