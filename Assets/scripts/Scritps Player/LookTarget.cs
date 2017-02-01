using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTarget : MonoBehaviour
{

    private GameObject target;
    public float visible = 10f;

    void Update()
    {

        RaycastHit hit;
        Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
        if (Physics.Raycast(ray, out hit, visible))
        {

            if (hit.transform.CompareTag("Enemy"))
            {
                GameObject.FindGameObjectWithTag("Player").transform.LookAt(hit.transform);
                /*target = GameObject.FindGameObjectWithTag(hit.transform.tag);
                GameObject Player = GameObject.FindGameObjectWithTag("Player");
                Player.transform.LookAt(target.transform);*/
            }

        }
    }
}