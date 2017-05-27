﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Demos;
using RootMotion.FinalIK;

public class TalkKeri : MonoBehaviour
{

    CharacterThirdPerson chart;
    PlayerAttack attPlayer;
    Animator animPlayer;
    Animator animKeri;
    GameObject trigger;

    public GameObject[] Text;
    public GameObject[] buttons;

    public float time;
    public float t;
    bool timeNow;

    void Start()
    {
        chart = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<CharacterThirdPerson>();
        attPlayer = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerAttack>();
        animKeri = GameObject.FindGameObjectWithTag("Keri").GetComponent<Animator>();
        animPlayer = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Animator>();
        time = 0;
        timeNow = false;
    }


    void Update()
    {
        if (timeNow)
        {
            time += Time.deltaTime;
           
        }
        if (time > t)
        {
            animKeri.SetBool("Talk", false);
            animPlayer.SetBool("Talk", false);
            if (time > t + t)
            {
                chart.enabled = true;
                attPlayer.enabled = true;
                animPlayer.SetLayerWeight(2, 0f);
                time = 0f;
                timeNow = false;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject button in buttons)
                button.gameObject.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                chart.enabled = false;
                attPlayer.enabled = false;
                animKeri.SetBool("Talk", true);
                animPlayer.SetLayerWeight(0, 0f);
                animPlayer.SetLayerWeight(2, 1f);
                animPlayer.SetBool("Talk", true);
                timeNow = true;
                if (time >= t + t)
                {
                    Destroy(trigger);
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject button in buttons)
                button.gameObject.SetActive(false);
        }
    }
}
