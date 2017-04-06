using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour {
	public bool state = false;
	private Shader s1;
	private Shader s2;
	// Use this for initialization
	void Start () {
		state = false;
		s1 = Shader.Find ("Standard");
		s2 = Shader.Find ("uSE - Refraction");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.R)) 
		{
			if (state == false) 
			{
				GetComponentInChildren<Renderer>().material.shader = s2;

			} 
			else
		    {
				GetComponentInChildren<Renderer>().material.shader = s1;
			}
			state = !state;
		}
	}
}
