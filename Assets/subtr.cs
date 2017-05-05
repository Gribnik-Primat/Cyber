using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class subtr : MonoBehaviour {
	public int num_of_strings;
	public string[] text;
	public bool enter_the_subt_box = false;
	public bool subtitles_shown = false;
	private int i=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (num_of_strings >= i) {			
			if (enter_the_subt_box == true) {
				GameObject.FindGameObjectWithTag ("Subtitles").GetComponent<Text> ().text = text[i];
				subtitles_shown = true;
				i++;
			}
		}
	}
}
