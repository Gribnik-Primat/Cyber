using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayer : MonoBehaviour {

    public GameObject player;
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        player.GetComponentInChildren<Animator>().SetLayerWeight(0, 1f);
        player.GetComponentInChildren<Animator>().SetLayerWeight(1, 0f);
        Destroy(gameObject);
	}
}
