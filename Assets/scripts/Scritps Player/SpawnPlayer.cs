using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

    
    public GameObject player;
   

	void Start ()
    {
	
	}
	
	
	void Update ()
    {

        Vector3 spawn = transform.position + Vector3.up; 
    
	if(player == null)
        {
           GameObject go = Instantiate(player,spawn,Quaternion.identity) as GameObject; 
        }
	}
}
