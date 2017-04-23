using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoDamageSpecial2 : MonoBehaviour {
	public Slider biostimSlider;
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
		gameObject.GetComponentInParent<Biostim> ().setBiostim (-30);
	//	biostimSlider.value -= 30;
    }
}
