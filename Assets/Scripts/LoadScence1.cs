using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScence1 : MonoBehaviour {

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
            pl.loadS1= true;
            Destroy(gameObject);
        }
    }
}
