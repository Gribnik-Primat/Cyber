using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour {
	public bool state = false;
    private Shader s1;
	private Shader s2;
	PlayerHack hack;
    GameObject[] Enemy;
    Biostim bio;
    float time;

	// Use this for initialization
	void Start () {

        bio = GetComponent<Biostim>();
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject e in Enemy)
        {
            e.GetComponent<EnemyMili>();
        }
        hack = GetComponentInChildren<PlayerHack>();
		//	state = false;
		s1 = Shader.Find ("Standard");
		s2 = Shader.Find ("uSE - Refraction");
	}

    // Update is called once per frame
    void Update()
    {   if (bio.biostim > 0f)
        {
            //if (GameObject.FindGameObjectWithTag("Biostim").GetComponent<Biostiminvisible>().activate == true && state == false) 
            //{   
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (!state)
                {

                    GetComponentInChildren<Renderer>().material.shader = s2;
                    hack.enabled = false;
                    foreach (GameObject e in Enemy)
                    {
                        e.GetComponent<EnemyMili>().invisibleplayer = true;
                    }
                    bio.Stels();

                }
                else
                /*if(GameObject.FindGameObjectWithTag("Biostim").GetComponent<Biostiminvisible>().activate == false && state == true)*/
                {

                    GetComponentInChildren<Renderer>().material.shader = s1;
                    hack.enabled = true;
                    foreach (GameObject e in Enemy)
                    {
                        e.GetComponent<EnemyMili>().invisibleplayer = false;
                    }
                    bio.Stels();
                   
                    //state = !state;
                }
                state = !state;
            }
        }
        else
        {
            GetComponentInChildren<Renderer>().material.shader = s1;
            hack.enabled = true;
          //  bio.biostim = 0;
           // bio.Stels();
            state = false;
        }
        
    }
	 
}
