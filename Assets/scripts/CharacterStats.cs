using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using RootMotion.FinalIK;
using RootMotion.Demos;
using System;

public class CharacterStats : MonoBehaviour {

    public float health = 100f;
   
    bool dealDamage;
    bool substractOnce;
    bool dead;
    public Transform[] items;

    public float damageTimer = .4f;
    WaitForSeconds damageT;

    public bool energi;

    Animator anim;
    Animator anim1;

    public GameObject sliderPrefabH;
   
    Slider healthSlider;

    RagdollUtility ragdollUtility;

    RectTransform healthTrans;

    

	void Start ()
    {
        damageT = new WaitForSeconds(damageTimer);
        anim = GetComponent<Animator>(); 
        anim1 = GetComponentInChildren<Animator>();
        
        GameObject slidH = Instantiate(sliderPrefabH, transform.position, Quaternion.identity) as GameObject;
        slidH.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        healthSlider = slidH.GetComponentInChildren<Slider>();
        healthTrans = slidH.GetComponent<RectTransform>();
        ragdollUtility = GetComponentInChildren<RagdollUtility>();
        
		//substractOnce = false;
    }

    

    void Update ()
    {
		
        healthSlider.value = health;
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
				
                health -= 30;

				substractOnce = true;

                anim1.SetTrigger("Hit");
                anim.SetTrigger("Hit");

            }

            StartCoroutine("CloseDamage");
        }
        if(health <= 0)
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
                  //  anim.SetBool("Dead", true);
               //     anim.CrossFade("Death", .5f);
                    Destroy(gameObject, 5f);
                }
                if (GetComponent<EnemyRobotAI>())
                {
                    anim.enabled = false;
                    GetComponent<EnemyRobotAI>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                  //  anim.SetBool("Dead", true);
                  //  anim.CrossFade("Death", .5f);
                    Destroy(gameObject, 5f);
                }
                if (GetComponent<EnemyAI>())
                {
                    anim.enabled = false;
                    GetComponent<EnemyAI>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                  //  anim.SetBool("Dead", true);
                 //  anim.CrossFade("Death", .5f);
                   Destroy(gameObject, 5f);

                }
                if (GetComponent<EnemyShootAi>())
                {
                    anim.enabled = false;
                    GetComponent<EnemyShootAi>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                   // anim.SetBool("Dead", true);
                    //  anim.CrossFade("Death", .5f);
                    Destroy(gameObject, 5f);

                } 
                else
                {
                    
                    //GetComponent<CharacterThirdPerson>().enabled = false;
                    GetComponentInChildren<PlayerAttack>().enabled = false;
                    anim1.enabled = false;
                    ragdollUtility.EnableRagdoll();
                    healthTrans.gameObject.SetActive(false);
                   // dealDamage = true;
                    GetComponent<CapsuleCollider>().enabled = false;
                    //  GetComponent<Rigidbody>().isKinematic = true;
                    Destroy(gameObject, 3f);
                    

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
        health -= value;
    }

    IEnumerator CloseDamage()
    {
        yield return damageT;
        dealDamage = false;
        substractOnce = false;

    }
}
