using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour {

	public Transform point;
    public float distanse;
    //CubeChange ch;
	void Start ()
    {
      //  ch = GetComponent<CubeChange>().chage;
        distanse = 15f;
	}
	
	

	void Update ()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, point.transform.position);
        Debug.DrawRay(transform.position, point.transform.position);
        if (Physics.Raycast(ray, out hit, distanse))
        {
            if (hit.transform.CompareTag("Key"))
            {
        //        ch = !ch;
            }
        }
	}
}
