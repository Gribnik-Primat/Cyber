using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTarget : MonoBehaviour
{

    public GameObject target;
    public float visible = 2f;
   
    bool spawntarget;
   
    void Update()
    {
       
                RaycastHit hit;
                Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
                if (Physics.Raycast(ray, out hit, visible))
                {

            if (hit.transform.CompareTag("Enemy"))
            {
               // transform.LookAt; Todo
            }

                }
            }
       }