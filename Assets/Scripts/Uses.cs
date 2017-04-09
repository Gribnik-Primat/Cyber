using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uses : MonoBehaviour {

    GameObject[] door;
    //GameObject d;
	void Start ()
    {
        door = GameObject.FindGameObjectsWithTag("Locker");
        foreach (GameObject d in door)
        {
            d.GetComponent<OpenDoorLock>();
        }
    }
	
	
	void Update ()
    {
        

        RaycastHit hit;
        Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
        Debug.DrawRay(transform.position + Vector3.up, transform.forward);
        if(Physics.Raycast(ray, out hit, 5f))
        {
            if (hit.transform.CompareTag("Locker"))
            {
               

                if (Input.GetButton("Uses"))
                {
                    foreach (GameObject d in door)
                    {
                        d.GetComponent<OpenDoorLock>().Change();
                       
                    }
                    
                  //  d.open = true;
                }
                
            }
        }


    }
}
