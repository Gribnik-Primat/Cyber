using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour {
	public bool state = false;
	private Shader s1;
	private Shader s2;
	PlayerHack hack;



	// Use this for initialization
	void Start () {

		hack = GetComponentInChildren<PlayerHack>();
		//	state = false;
		s1 = Shader.Find ("Standard");
		s2 = Shader.Find ("uSE - Refraction");
	}

	// Update is called once per frame
	void Update () 
	{
		if (GameObject.FindGameObjectWithTag("Biostim").GetComponent<Biostiminvisible>().activate == true && state == false) 
		{              
			GetComponentInChildren<Renderer>().material.shader = s2;
			hack.enabled = false;
			state = !state;
		} 
		else if(GameObject.FindGameObjectWithTag("Biostim").GetComponent<Biostiminvisible>().activate == false && state == true)
		{

			GetComponentInChildren<Renderer>().material.shader = s1;
			hack.enabled = true;
			state = !state;
		}
	}
}
