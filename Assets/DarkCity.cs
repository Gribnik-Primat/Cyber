using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkCity : MonoBehaviour {

	
	void Start ()
    {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterStatsPlayer>())
        {
            Application.LoadLevel(2);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
