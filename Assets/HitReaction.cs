using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using RootMotion.Demos;

public class HitReaction : MonoBehaviour {
    HitReaction hitReaction;
    float hitForce = 1f;
    
    void Start ()
    {
		
	}


    void Update()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(transform.position, Vector3.forward);
        if (Physics.Raycast(ray, out hit, 100f))
        {

            // Use the HitReaction
          //  hitReaction.Hit(hit.collider, ray.direction * hitForce, hit.point);
        }
    }
}
