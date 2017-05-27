using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public GameObject Player;
    public bool loadS;
    public bool loadS1;
    void Start ()
    {
        loadS = false;
        loadS1 = false;
	}
	
	
	void Update ()
    {
        if (!Player)
        {
            if (loadS)
            {
                Application.LoadLevel(2);
            }
            if (loadS1)
            {
                Application.LoadLevel(3);
            }
        }
	}
}
