using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedgo : MonoBehaviour {

    
    Animator anim;
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("see", true);
        }
        else
            anim.SetBool("see", false);
    }
}
