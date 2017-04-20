using UnityEngine;
using System.Collections;

public class DoDamageP : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
		if (other.GetComponent<CharacterStatsPlayer>())
        {
			
            other.GetComponent<CharacterStatsPlayer>().checkToApplyDamage();
        }
    }
	
	
}
