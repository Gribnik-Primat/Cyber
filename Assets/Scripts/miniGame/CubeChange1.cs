using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeChange1 : MonoBehaviour
{

    Animator anim;
    public bool change;
	void Start ()
    {
        change = false;
        anim = GetComponent<Animator>();
	}
	
	
	void Update ()
    {
        if (change)
        {
            anim.SetBool("open", true);
            anim.SetBool("close", false);
        }
        if(!change)
        {
            anim.SetBool("open", false);
            anim.SetBool("close", true);
        }

	}
}
