using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkCity : MonoBehaviour {
   
   
  //  public GameObject boss;
	void Start ()
    {
        
        
	}
    void OnTriggerEnter(Collider other)
    {
            if (other.GetComponent<CharacterStatsPlayer>())
            {
                Application.LoadLevel(3);
            }
    }
}
