using UnityEngine;
using System.Collections;

public class DoDamagePlayer : MonoBehaviour {

    AudiPlayer audio;

    void Start()
    {
        audio = GetComponentInParent<AudiPlayer>();
    }
	void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterStatsEnemy>())
        {
            other.GetComponent<CharacterStatsEnemy>().checkToApplyDamage();
            audio.shoot = true;
        }
    }
	
	
}
