using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

    
    public GameObject player;
    public GameObject spawn;
    public bool death = false;
   
    void Start ()
    {
	
	}

    public void Death()
    {
        death = true;
    }

    void Update ()
    {

       
    
	if(death)
        {
           GameObject go = Instantiate(player, spawn.transform.position, Quaternion.identity) as GameObject;
            death = false;
           
        }
	}
    
}
