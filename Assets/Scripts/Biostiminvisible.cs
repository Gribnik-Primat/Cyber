using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biostiminvisible : MonoBehaviour {
	public bool activate = false;
	public float timelimit = 4f;
	bool startcountdown = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			startcountdown = true;
			activate = true;

			gameObject.GetComponentInChildren<Renderer>().enabled=false;
		}
	}

	void Update()
	{
		if (startcountdown == true)
			timelimit -= Time.deltaTime;
		if(timelimit<=0)
		{
			activate = false;
			startcountdown= false;
			timelimit = 4f;
			Destroy (gameObject);
		}
	}
}
