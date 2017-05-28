using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tobe : MonoBehaviour {

    public GameObject toBe;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            toBe.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            toBe.SetActive(false);
        }
    }
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}
}
