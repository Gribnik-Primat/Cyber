using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour {

	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        Vector2 toPosition = new Vector2(0,600);
        transform.localPosition = Vector2.Lerp(transform.localPosition, toPosition, 0.1f * Time.deltaTime);

    }
}
