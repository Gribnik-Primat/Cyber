using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biostiminvisible : MonoBehaviour {

   
        GameObject bio;
	// Use this for initialization
	void Start ()
    {
        bio = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
            bio.GetComponent<Biostim>().biostim += 50f;
            // gameObject.GetComponentInChildren<Renderer>().enabled=false;
            Destroy(gameObject);
        }
	}

	void Update()
	{	
			
	}
}
