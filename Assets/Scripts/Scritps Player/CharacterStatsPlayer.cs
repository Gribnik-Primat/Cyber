using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using RootMotion.FinalIK;
using RootMotion.Demos;
using System;

public class CharacterStatsPlayer : MonoBehaviour {

    public float healthP = 100f;
   
    bool dealDamage;
    bool substractOnce;
    bool dead;
   // public Transform[] items;

    public float damageTimer = .4f;
    WaitForSeconds damageT;

    public bool energi;

    Animator anim;

    Biostim bio;
    //public GameObject sliderPrefabH;
   
   public Slider healthSlider;
   
    RagdollUtility ragdollUtility;

    //RectTransform healthTrans;

    

	void Start ()
    {
        damageT = new WaitForSeconds(damageTimer);
        
        anim = GetComponentInChildren<Animator>();
        bio = GetComponentInParent<Biostim>();
        //GameObject slidH = Instantiate(sliderPrefabH, transform.position, Quaternion.identity) as GameObject;
        //slidH.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        //healthSlider = slidH.GetComponentInChildren<Slider>();
        //healthTrans = slidH.GetComponent<RectTransform>();
        ragdollUtility = GetComponentInChildren<RagdollUtility>();
        
		//substractOnce = false;
    }

    

    void Update ()
    {
        healthSlider.value = healthP;

        if (healthP > 100)
        {
            healthP = 100;
        }
        if (healthP < 0)
        {
            healthP = 0;
        }
        //if (healthSlider.value >= 100 || healthSlider.value <= 0)
        //	healthSlider.gameObject.SetActive (false);
        //else
        //	healthSlider.gameObject.SetActive (true);
        //Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
        //      healthTrans.transform.position = screenPoint;
        if (dealDamage)
        {
            if (substractOnce == false)
            {				
                healthP -= 20;
                substractOnce = true;
                anim.SetTrigger("Hit");
            }

            StartCoroutine("CloseDamage");
        }
        if(healthP <= 0)
        {
            if (!dead)
            {
                //for(int i = 0; i<items.Length; i++)
                //{
                //    items[i].parent = null;
                //    items[i].GetComponent<Rigidbody>().isKinematic = false;
                //}
                    
                    GetComponent<CharacterThirdPerson>().enabled = false;
                    GetComponentInChildren<PlayerAttack>().enabled = false;
                    anim.enabled = false;
                    ragdollUtility.EnableRagdoll();
                    healthSlider.gameObject.SetActive(false);
                    bio.biostimSlider.gameObject.SetActive(false);
                   // dealDamage = true;
                    GetComponent<CapsuleCollider>().enabled = false;
                    //  GetComponent<Rigidbody>().isKinematic = true;
                    Destroy(gameObject, 2f);
                }
                dead = true;
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
        healthP -= value;
    }

    IEnumerator CloseDamage()
    {
        yield return damageT;
        dealDamage = false;
        substractOnce = false;

    }
}
