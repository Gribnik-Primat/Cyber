using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour {

    CubeChange1 cube;
    
	void Start ()
    {
        cube =GameObject.FindGameObjectWithTag("Key").GetComponent<CubeChange1>();
       
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CubeChange1>())
        {
            cube.change = true;
            //if (Input.GetKeyDown(KeyCode.Space))
            //{

            //    if (cube.change == false)
            //    {
            //        cube.change = true;
            //    }
            //    else
            //    {
            //        cube.change = false;
            //    }


            //}



        }


    }
	

	void Update ()
    {
        
         
	}
}
