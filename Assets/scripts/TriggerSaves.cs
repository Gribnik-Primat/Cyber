using UnityEngine;
using System.Collections;

public class TriggerSaves : MonoBehaviour {

    Saves save; 


    void Start ()
    {
       

    }
	
	void OnTriggerEnter(Collider other)
    {
        save = GameObject.FindGameObjectWithTag("TriggerSave").GetComponent<Saves>();//тэг относится к объекту-невидимке saves
        if (other.GetComponent<PlayerMovement>())
        {
            save.s = true;
            save.Save();
            Destroy(gameObject);
        }
    }
	void Update ()
    {
	
	}
}
