﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Demos;

public class Rotate : MonoBehaviour {
    
    float time = 0;
  private bool act = false;
 
    	
	void Update ()
    {
        if (act)
        {
            time += Time.deltaTime;
        }
        if (time>= 2f)
            transform.Rotate(Vector3.up, 180f);


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterThirdPerson>())
        {   
            act = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterThirdPerson>())
        {
            act = false;

            time = 0;
        }
    }
}
