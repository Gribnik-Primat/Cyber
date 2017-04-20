using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DoDamagePlayer : MonoBehaviour {
	int count = 0;
	int rand  = Random.Range(2,5);
    AudiPlayer audio;
	public Slider biostimSlider;
    void Start()
    {
        audio = GetComponentInParent<AudiPlayer>();
    }
	void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterStatsEnemy>())
        {
			count++;
			if (count >= rand) 
			{
				rand = Random.Range(2,5);
				count = 0;
				other.GetComponent<CharacterStatsEnemy> ().ragdoll_func_on ();
			}
			gameObject.GetComponentInParent<Biostim> ().setBiostim (2);
			biostimSlider.value += 2;
            other.GetComponent<CharacterStatsEnemy>().checkToApplyDamage();
            audio.shoot = true;
        }
    }
	
	
}
