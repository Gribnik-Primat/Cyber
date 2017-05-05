using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show_text : MonoBehaviour {

	bool text_show = false;
	Time t;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		text_show = GameObject.FindGameObjectWithTag ("Player").GetComponent<subtr>().subtitles_shown;
		if (text_show == true && t < 5.0f) {
			//АКТИВАЦИЯ ТЕКСТА СУБТИТРОВ НА ЭКРАН
		}
		else
		{
			text_show = false;
			//ДЕАКТИВАЦИЯ ТЕКСТА СУБТИТРОВ
		}
	}
}
