using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotCam : MonoBehaviour
{
    public float right;
    public float left;
   
    private int sign;
    // Use this for initialization 
    void Start()
    {
        sign = -1;
       
        
    }

    // Update is called once per frame 
    void Update()
    {
        if (transform.rotation.eulerAngles.x > left)
            sign = -1;
        if (transform.rotation.eulerAngles.x < right)
            sign = 1;
        transform.Rotate(sign * Vector3.up * Time.deltaTime * 100, Space.World);
       
        
    }
}
