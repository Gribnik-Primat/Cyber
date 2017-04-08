using UnityEngine;
using System.Collections;

public class DoDamagePlayer : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterStatsEnemy>())
        {
			
            other.GetComponent<CharacterStatsEnemy>().checkToApplyDamage();
        }
    }
	
	
}
