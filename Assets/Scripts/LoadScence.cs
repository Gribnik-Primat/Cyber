using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScence : MonoBehaviour {

    player pl;
	
	void Start ()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<player>();
	}
	
	
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pl.loadS= true;
            Destroy(gameObject);
        }
    }
}
