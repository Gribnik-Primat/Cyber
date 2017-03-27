using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Demos;

public class Rotate : MonoBehaviour {
    public Transform enemy;
    public float time = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterThirdPerson>())
        {
            time += time + Time.deltaTime;
            //if (time >= 2f)
            //{
                transform.Rotate(Vector3.up, 180f);
            //}
        }
        else
        {
            time = 0;
        }
    }


	void Start () {
		
	}
	
	
	void Update () {
		
	}
}
