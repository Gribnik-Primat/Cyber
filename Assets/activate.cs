using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activate : MonoBehaviour {
	public Slider slide;
	// Use this for initialization
	float time;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other)
	{
		if(Input.GetKeyDown(KeyCode.E))
			{
			time += Time.deltaTime;
		   		slide.value += time*20;
			if (slide.value == 100) {
				if (other.gameObject.tag == "Player") {
					other.gameObject.GetComponentInChildren<Animator> ().SetLayerWeight (0, 1f);

					other.gameObject.GetComponentInChildren<Animator> ().SetLayerWeight (1, 0);
					Destroy (GameObject.FindGameObjectWithTag("Loading"));
				}
			}
			}
	}
}
