using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject Bulet; 
   // public AudioSource audio;
    public float waitTime = .15f;
    private float wait = 0f;

    public Transform spawnPos;
   
    public GameObject damagecoll;


    void Start()
    {
        //audio = GetComponent<AudioSource>();
    }


    public void shooting()
    {
        
        if (wait <= 0f)
        {
            wait = waitTime;
           // audio.Play();
        }

        GameObject AmmoBulet = Instantiate(Bulet, spawnPos.transform.position, spawnPos.transform.rotation) as GameObject;
        AmmoBulet.GetComponent<Rigidbody>().AddForce(-transform.forward * 1000f);


    }
    void Update()
    {
        if (wait > 0)
            wait -= Time.deltaTime;
    }

}

