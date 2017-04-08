using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiEnemy : MonoBehaviour {

    AudioSource audio;
    public AudioClip[] clips;
    public bool shoot;
    void Start ()
    {
        shoot=false;
        audio = GetComponent<AudioSource>();
        audio.playOnAwake=false;
        audio.loop = false;

	}
	
	
	void Update ()
    {
        if (!audio.isPlaying)
        {
          



                if (shoot)
            {
                audio.clip = clips[0];
                shoot = false;
                audio.Play();
            }
            else
            {
                audio.Stop();
            }
            
        }
        
    }
}
