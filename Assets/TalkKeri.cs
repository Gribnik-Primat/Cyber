using System.Collections;
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

    public GameObject task;

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
            if (time > 20 && time < 24)
            {
                Text[4].SetActive(false);
                Text[5].SetActive(true);
            }
            if (time > 24 && time < 28)
            {
                Text[5].SetActive(false);
                Text[6].SetActive(true);
            }
            if (time > 28 && time < 32)
            {
                Text[6].SetActive(false);
                Text[7].SetActive(true);
            }
            if (time > 32 && time < 36)
            {
                Text[7].SetActive(false);
                Text[8].SetActive(true);
            }
        }
        if (time > t)
        {
          //  animKeri.SetBool("Talk", false);
           // animPlayer.SetBool("Talk", false);
            if (time > t + t)
            {
                animKeri.SetBool("Talk", false);
                animPlayer.SetBool("Talk", false);
                task.SetActive(true);
                Text[8].SetActive(false);
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
