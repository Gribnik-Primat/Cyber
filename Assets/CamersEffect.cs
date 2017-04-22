using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class CamersEffect : MonoBehaviour {

    VignetteAndChromaticAberration vig;
    public float time;
    public float v;
	void Start ()
    {
        vig = GetComponent<VignetteAndChromaticAberration>();
        v = 0f;
	}
	
	
	void Update ()
    {
        v += 10f*Time.deltaTime;

        time += Time.deltaTime;
        if (time > 4f &&time < 8f)
        {

        vig.intensity += v * Time.deltaTime; ;
           

        }
      if (time > 8f&& time < 10f)
        {
         vig.intensity -= v *Time.deltaTime;
            
        }
        if (time > 10f)
        {
            vig.intensity = v;

        }

    }
}
