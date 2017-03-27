using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uses : MonoBehaviour {

    //  OpenDoorLock door;
    bool door;
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position + Vector3.up, transform.forward + Vector3.up);
        if(Physics.Raycast(ray, out hit, 3f))
        {
            if (hit.transform.CompareTag("Locker"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    door =GetComponent<OpenDoorLock>().open = true;
                }
            }
        }


    }
}
