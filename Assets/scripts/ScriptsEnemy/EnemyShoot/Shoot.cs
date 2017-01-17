using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    LineRenderer line;
    private float time = 0;
    
    public Transform spawnPos;
    public bool see = false;
    public GameObject damagecoll;


    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
    }


    public void shooting()
    {
        if (see)
        {
            StopCoroutine("FireLaser");
            StartCoroutine("FireLaser");
        }

    }
    IEnumerator FireLaser()
    {
        line.enabled = true;
        while (see)
        {
            Ray ray = new Ray(spawnPos.position, transform.forward);
            RaycastHit hit;
            Debug.DrawRay(spawnPos.position, transform.forward * 100f);
            line.SetPosition(0, ray.origin);
            if (Physics.Raycast(ray, out hit, 10))
            {
                line.SetPosition(1, hit.point);
                if (hit.collider.CompareTag("Player"))
                {
                    GameObject damage = Instantiate(damagecoll, hit.transform.position, Quaternion.identity) as GameObject;
                    Destroy(damagecoll, 0.4f);
                }
            }
            else
                line.SetPosition(1, ray.GetPoint(15));

            yield return null;
        }
        line.enabled = false;
    }
}

