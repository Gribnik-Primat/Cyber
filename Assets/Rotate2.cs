using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Demos;

public class Rotate2 : MonoBehaviour {

    float time = 0;
    private bool act = false;
    public GameObject enemy;
   // Rotate rot2;
 // public  GameObject attack;

    void Start()
    {
        //  rot2 = GetComponent<Rotate>();
       // attack = GameObject.FindGameObjectWithTag("Player"); 
       
    }
    void Update()
    {

        if (act)
        {
            time += Time.deltaTime;
        }
        if (time >= 3f)
            enemy.transform.Rotate(Vector3.up, 180f);
      //  rot2.gameObject.SetActive(false);


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterThirdPerson>())
        {
            act = true;
          //  attack.GetComponent<PlayerAttack>().damage();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterThirdPerson>())
        {
            act = false;
            time = 0;
          //  attack.GetComponent<PlayerAttack>().damage();
            // rot2.gameObject.SetActive(true);
        }
    }
}