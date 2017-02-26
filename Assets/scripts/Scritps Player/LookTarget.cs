using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTarget : MonoBehaviour
{

    public float visible = 10f;
    Transform target;

	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Enemy").transform;
	}
    void Update()
    {

        RaycastHit hit;
		Ray ray = new Ray(transform.position + Vector3.up, transform.position - target.transform.position);
        if (Physics.Raycast(ray, out hit, visible))
        {

            if (hit.transform.CompareTag("Enemy"))
            {
                GameObject.FindGameObjectWithTag("Player").transform.LookAt(hit.transform);
            }

        }
    }
}