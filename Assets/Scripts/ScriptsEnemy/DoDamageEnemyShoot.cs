using UnityEngine;
using System.Collections;

public class DoDamageEnemyShoot : MonoBehaviour {

    AudiEnemy au;
    void Start()
    {
        au = GetComponentInParent<AudiEnemy>();
    }
	void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterStatsPlayer>() )
        {
            other.GetComponent<CharacterStatsPlayer>().checkToApplyDamage();
            au.shoot = true;
        }
        if (other.GetComponent<CharacterStatsEnemy>())
        {
            other.GetComponent<CharacterStatsEnemy>().checkToApplyDamage();
        }

    }
	
	
}
