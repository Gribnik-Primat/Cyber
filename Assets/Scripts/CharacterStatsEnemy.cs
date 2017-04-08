﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using RootMotion.FinalIK;
using RootMotion.Demos;
using System;

public class CharacterStatsEnemy : MonoBehaviour {

    public float healthE = 100f;
   
    bool dealDamage;
    bool substractOnce;
    bool dead;
   // public Transform[] items;

    public float damageTimer = .4f;
    WaitForSeconds damageT;

    public bool energi;

    Animator anim;

    public GameObject sliderPrefabH;
   
    Slider healthSlider;

    RagdollUtility ragdollUtility;

    RectTransform healthTrans;

    

	void Start ()
    {
        damageT = new WaitForSeconds(damageTimer);
        anim = GetComponent<Animator>(); 
       
        
        GameObject slidH = Instantiate(sliderPrefabH, transform.position, Quaternion.identity) as GameObject;
        slidH.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        healthSlider = slidH.GetComponentInChildren<Slider>();
        healthTrans = slidH.GetComponent<RectTransform>();
        ragdollUtility = GetComponentInChildren<RagdollUtility>();
        
		//substractOnce = false;
    }

    

    void Update ()
    {
		
        healthSlider.value = healthE;
		if (healthSlider.value >= 100 || healthSlider.value <= 0)
			healthSlider.gameObject.SetActive (false);
		else
			healthSlider.gameObject.SetActive (true);
		Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
        healthTrans.transform.position = screenPoint;
       


        if (dealDamage)
        {
            if (substractOnce == false)
            {
                healthE -= 30;
				substractOnce = true;
                anim.SetTrigger("Hit");
            }

            StartCoroutine("CloseDamage");
        }
        if(healthE <= 0)
        {
            if (!dead)
            {
                //for(int i = 0; i<items.Length; i++)
                //{
                //    items[i].parent = null;
                //    items[i].GetComponent<Rigidbody>().isKinematic = false;
                //}

                if (GetComponent<EnemyMili>())
                {
                    GetComponent<EnemyMili>().enabled = false;
                    anim.enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
              
                    Destroy(gameObject, 5f);
                }
                if (GetComponent<EnemyRobotAI>())
                {
                    anim.enabled = false;
                    GetComponent<EnemyRobotAI>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                 
                    Destroy(gameObject, 5f);
                }
                if (GetComponent<EnemyAI>())
                {
                    anim.enabled = false;
                    GetComponent<EnemyAI>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                 
                   Destroy(gameObject, 5f);

                }
                if (GetComponent<EnemyShootAi>())
                {
                    anim.enabled = false;
                    GetComponent<EnemyShootAi>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                  
                    Destroy(gameObject, 5f);

                } 
                dead = true;
            }
            
        }
	}

    public void checkToApplyDamage()
    {
        if (!dealDamage)
        {
            dealDamage = true;
        }
    }

    public void damage(float value)
    {
        healthE -= value;
    }

    IEnumerator CloseDamage()
    {
        yield return damageT;
        dealDamage = false;
        substractOnce = false;

    }
}