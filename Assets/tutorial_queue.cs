using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_queue : MonoBehaviour {

	public GameObject[] tutorials;
	int id = 0;
	// Use this for initialization
	void Start () {
		id = 0;
		for (int j = 1; j < tutorials.Length; j++)
			tutorials[j].SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (id <= tutorials[tutorials.Length-1].GetComponent<play_tutorial>().id) {
			if (tutorials [id].activeSelf == false) {
				for (int j = 0; j < tutorials.Length; j++)
					if (tutorials [j].GetComponent<play_tutorial>().id == id)
						tutorials [j].SetActive (false);
				id++;
				for (int j = 0; j < tutorials.Length; j++)
					if (tutorials [j].GetComponent<play_tutorial>().id == id)
						tutorials [j].SetActive (true);
			}
		}
	}
}
