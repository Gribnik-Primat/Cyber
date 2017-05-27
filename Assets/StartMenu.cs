using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour {
    float time;
	public float t;
	void Start ()
    {
        time = 0;
	}
	
	
	void Update ()
    {
        time += Time.deltaTime;
        if(time > t)
        {
            Application.LoadLevel(0);
            time = 0;
        }
	}
}
