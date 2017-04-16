using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public GameObject Player;
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        if (!Player)
        {
            Application.LoadLevel(0);
        }
	}
}
