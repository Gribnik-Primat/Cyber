using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotCam : MonoBehaviour
{

    Animator anim;
    public bool activeCam = false;
  //  public Light light;

    void Start()
    {
        anim = GetComponent<Animator>();
       // light = GetComponent<Light>();
    }

    
    void Update()
    {

        if (activeCam)
        {
           // изменить цвет
            anim.Stop();
        }
        
    }
}
