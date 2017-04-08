using UnityEngine;
using System.Collections;

public class DoDamageEnemy : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterStatsPlayer>())
        {
			
            other.GetComponent<CharacterStatsPlayer>().checkToApplyDamage();
        }
    }
	
	
}
