using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorLock : MonoBehaviour {
    public GameObject door;
    public bool open = false;

    public float doorOpenAngleX;
    public float doorOpenAngleY;
    public float doorOpenAngleZ;

    public float doorCloseAngleX;
    public float doorCloseAngleY;
    public float doorCloseAngleZ;

    public float smooth = 2f;

    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        
            if (open) //open == true
            {
                Quaternion targetRotation = Quaternion.Euler(doorOpenAngleX, doorOpenAngleY, doorOpenAngleZ);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
            }
            else
            {
                Quaternion targetRotation2 = Quaternion.Euler(doorCloseAngleX, doorCloseAngleY, doorCloseAngleZ);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
            }
    }

    
}

