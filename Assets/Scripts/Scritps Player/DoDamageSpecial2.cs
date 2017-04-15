using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamageSpecial2 : MonoBehaviour {

    void Start()
    {
      //  audio = GetComponentInParent<AudiPlayer>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterStatsEnemy>())
        {
            other.GetComponent<CharacterStatsEnemy>().checkToApplyDead();
           // audio.shoot = true;
        }
    }
}
