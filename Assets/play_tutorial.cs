using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class play_tutorial : MonoBehaviour {
	public AudioClip clip;
	AudioSource audio;	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		audio.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			audio.Play();
		}
	}
}
