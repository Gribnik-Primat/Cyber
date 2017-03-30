using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotCam : MonoBehaviour
{

    Animator anim;
    public bool activeCam = false;
	Light col;

  //  public Light light;

    void Start()
    {
        anim = GetComponent<Animator>();
		col = GetComponentInChildren<Light>();
		// light = GetComponent<Light>();
    }

    
    void Update()
    {

        if (activeCam)
        {
			col.color = Color.red;
           // изменить цвет
            anim.Stop();
        }
        
    }
}
