using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_tutorial : MonoBehaviour {
	public AudioClip clip;
	// Use this for initialization
	bool disable = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (disable == true)
			collider.isTrigger = false;
		else
			collider.isTrigger = true;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			AudioSource.PlayClipAtPoint(clip, transform.position);
		}
		disable = true;
	}

}
