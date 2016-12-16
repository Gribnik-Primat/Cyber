using UnityEngine;
using System.Collections;

public class DoDamage : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterStats>())
        {
            other.GetComponent<CharacterStats>().checkToApplyDamage();
        }
    }
	
	
}
