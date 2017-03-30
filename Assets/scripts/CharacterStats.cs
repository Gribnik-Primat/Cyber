using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using RootMotion.Demos;
using System;

public class CharacterStats : MonoBehaviour {

    public float health = 100f;
    public float biostim = 100f;
    bool dealDamage;
    bool substractOnce;
    bool dead;
    public Transform[] items;

    public float damageTimer = .4f;
    WaitForSeconds damageT;

    public bool energi;

    Animator anim;

    public GameObject sliderPrefabH;
   
    Slider healthSlider;
    

    
    RectTransform healthTrans;



	void Start ()
    {
        damageT = new WaitForSeconds(damageTimer);
        anim = GetComponent<Animator>();

        GameObject slidH = Instantiate(sliderPrefabH, transform.position, Quaternion.identity) as GameObject;
        slidH.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        healthSlider = slidH.GetComponentInChildren<Slider>();
        healthTrans = slidH.GetComponent<RectTransform>();

        
		substractOnce = false;
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

				anim.SetTrigger("Hit");

            }

            StartCoroutine("CloseDamage");
        }
        if(health <= 0)
        {
            if (!dead)
            {
                anim.SetBool("Dead", true);
                anim.enabled = false;
                healthTrans.gameObject.SetActive(false);
                
                dealDamage = true;


                GetComponent<CapsuleCollider>().enabled = false;
              //  GetComponent<Rigidbody>().isKinematic = true;
                Destroy(gameObject, 3f);

			

                for(int i = 0; i<items.Length; i++)
                {
                    items[i].parent = null;
                    items[i].GetComponent<Rigidbody>().isKinematic = false;
                }

                if (GetComponent<EnemyMili>())
                {
                    GetComponent<EnemyMili>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                    anim.SetBool("Dead", true);
               //     anim.CrossFade("Death", .5f);
                    Destroy(gameObject, 5f);
                }
                if (GetComponent<EnemyRobotAI>())
                {
                    GetComponent<EnemyRobotAI>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                    anim.SetBool("Dead", true);
                  //  anim.CrossFade("Death", .5f);
                    Destroy(gameObject, 5f);
                }
                if (GetComponent<EnemyAI>())
                {
                    GetComponent<EnemyAI>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                    anim.SetBool("Dead", true);
                 //  anim.CrossFade("Death", .5f);
                   Destroy(gameObject, 5f);

                }
                if (GetComponent<EnemyShootAi>())
                {
                    GetComponent<EnemyShootAi>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                    anim.SetBool("Dead", true);
                    //  anim.CrossFade("Death", .5f);
                    Destroy(gameObject, 5f);

                }
                else
                {
                    //GetComponent<PlayerInput>().enabled = false;
                    //GetComponent<PlayerMovement>().enabled = false;
                    GetComponent<PlayerAttack>().enabled = false;
                    
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

   // IEnumerator CloseDamage()
   // {
   //     yield return damageT;
   //     dealDamage = false;
   //     substractOnce = true;
	//
    //}
}
