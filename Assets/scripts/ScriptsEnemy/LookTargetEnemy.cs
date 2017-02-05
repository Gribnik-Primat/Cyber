using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTargetEnemy : MonoBehaviour
{

    public float visible = 10f;

    void Update()
    {

        RaycastHit hit;
        Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
        if (Physics.Raycast(ray, out hit, visible))
        {

            if (hit.transform.CompareTag("Player"))
            {
                GameObject.FindGameObjectWithTag("Enemy").transform.LookAt(hit.transform);
            }

        }
    }
}