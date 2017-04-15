using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Demos;

public class Rotate : MonoBehaviour {
   
    float time = 0;
  private bool act = false;
    public GameObject enemy;
   // Rotate2 rot;

    void Start()
    {
       // rot = GetComponent<Rotate2>();
    }

    void Update ()
    {
   
        if (act)
        {
            time += Time.deltaTime;
        }
        if (time>= 1.5f)
            enemy.transform.Rotate(Vector3.up, 180f);
          //  rot.gameObject.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterThirdPerson>())
        {   
            act = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterThirdPerson>())
        {
            act = false;

            time = 0;
         //   rot.gameObject.SetActive(true);
        }
    }
}
