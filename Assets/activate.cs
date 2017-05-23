using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activate : MonoBehaviour {
	public Slider slide;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && Input.GetKey (KeyCode.E))
			other.gameObject.GetComponentInParent<Animator>().SetLayerWeight(0,0);
	}
}
