using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DoDamagePlayer : MonoBehaviour {
    [SerializeField]
    int count;
    [SerializeField]
    int rand;
    AudiPlayer audio;
	public Slider biostimSlider;
    void Start()
    {    rand = Random.Range(2, 5);
        count = 0;
        audio = GetComponentInParent<AudiPlayer>();
    }
	void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterStatsEnemy>())
        {
            //int count = 0;
            //int rand = Random.Range(2, 5);
            count++;
			if (count >= rand) 
			{
				rand = Random.Range(2,5);
				count = 0;
				other.GetComponent<CharacterStatsEnemy> ().ragdoll_func_on ();
			}
			gameObject.GetComponentInParent<Biostim> ().setBiostim (5f);
		//	biostimSlider.value += 2f;
            other.GetComponent<CharacterStatsEnemy>().checkToApplyDamage();
            audio.shoot = true;
        }
    }
	
	
}
