using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadtest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterStatsPlayer>())
        {
            Application.LoadLevel(2);
        }
    }
}
