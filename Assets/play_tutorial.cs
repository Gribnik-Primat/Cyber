using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent (typeof(AudioSource))]

public class play_tutorial : MonoBehaviour
{
	public int id;
	public AudioClip clip;
	AudioSource audio;
	// Use this for initialization

	public GameObject[] buttons;
	public GameObject[] doors;
	public float time_for_doors_closed;

	float time;
	bool exit = false;
	float time_to_wait;

	void Start ()
	{
		audio = GetComponent<AudioSource> ();
		audio.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*if (exit == true) {
			time_to_wait += Time.deltaTime;
			if (time_to_wait > exit_time) {
				this.gameObject.SetActive (false);
			}
		}*/
		if (audio.isPlaying == false && exit == true) {
			this.gameObject.SetActive (false);
		}
			
			
	}

	void OnTriggerStay (Collider other)
	{
		time += Time.deltaTime;
		if (doors.Length > 0) {
			if (time >= time_for_doors_closed) {
				foreach (GameObject door in doors)
					door.gameObject.GetComponent<OpenClose> ().enabled = true;
			}
		}
		if (other.gameObject.tag == "Player") {
			foreach (GameObject button in buttons)
				button.gameObject.SetActive (true);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (doors.Length > 0) {
			foreach (GameObject door in doors)
				door.gameObject.GetComponent<OpenClose> ().enabled = false;
		}
		if (other.gameObject.tag == "Player") {
			audio.Play ();
		}
	}

	void OnTriggerExit (Collider other)
	{
		exit = true;
		if (other.gameObject.tag == "Player") {
			foreach (GameObject button in buttons)
				button.gameObject.SetActive (false);
		}

	}
}
