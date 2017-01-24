using UnityEngine;
using System.Collections;

public class TriggerSaves : MonoBehaviour {

    Saves save;
   
	
	void Start ()
    {
       save = GameObject.FindGameObjectWithTag("GameController").GetComponent<Saves>();

    }
	
	void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            save.s = true;
            Destroy(gameObject);
        }
    }
	void Update ()
    {
	
	}
}
