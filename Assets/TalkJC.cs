using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Demos;
using RootMotion.FinalIK;

public class TalkJC : MonoBehaviour
{

    CharacterThirdPerson chart;
    PlayerAttack attPlayer;
    Animator animPlayer;
    Animator animJC;
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
        animJC = GameObject.FindGameObjectWithTag("JC").GetComponent<Animator>();
        animPlayer = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Animator>();
        time = 0;
        timeNow = false;
    }


    void Update()
    {
        if (timeNow)
        {
            time += Time.deltaTime;
            if (time > 0 && time < 4)
            {
                Text[0].SetActive(true);
            }
            if (time > 4 && time < 8)
            {
                Text[0].SetActive(false);
                Text[1].SetActive(true);
            }
            if (time > 8 && time < 12)
            {
                Text[1].SetActive(false);
                Text[2].SetActive(true);
            }
            if (time > 12 && time < 16)
            {
                Text[2].SetActive(false);
                Text[3].SetActive(true);
            }
            if (time > 16 && time < 20)
            {
                Text[3].SetActive(false);
                Text[4].SetActive(true);
            }
        }
        if (time > t)
        {
            animJC.SetBool("TalkPoint", true);
            animPlayer.SetBool("Talk", false);
            if (time > t + t)
            {
                Text[4].SetActive(false);
                animJC.SetBool("SitStand", false);
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
                animJC.SetBool("SitStand", true);
                animJC.SetBool("Talk", true);
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

