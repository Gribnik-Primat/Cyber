using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using RootMotion.FinalIK;
using RootMotion.Demos;
using System;

public class CharacterStatsEnemy : MonoBehaviour {

    public float healthE = 100f;
    public float lookHealth = 100f;
    bool dealDamage;
    bool substractOnce;
    bool dead;
    bool dealDead;
    bool deal;
	bool ragdoll_state;
   // public Transform[] items;

    public float damageTimer = .4f;
    WaitForSeconds damageT;

	public float ragdoll_time = 1.5f;
   
    Animator anim;

    public GameObject sliderPrefabH;
   
    Slider healthSlider;

    RagdollUtility ragdollUtility;

	FullBodyBipedIK fbbik;

    RectTransform healthTrans;
    Rotate rot;
    Rotate2 rot2;
    LookAtIK Look;
    BoxCollider box;
    CapsuleCollider capsul;
    DarkCity dark;
    UnityEngine.AI.NavMeshAgent agent;
    

    void Start ()
    {
        box=GetComponentInChildren<BoxCollider>();
        damageT = new WaitForSeconds(damageTimer);
        anim = GetComponent<Animator>();
        rot = GetComponentInChildren<Rotate>();
        rot2 = GetComponentInChildren<Rotate2>();
        Look = GetComponent<LookAtIK>();
        GameObject slidH = Instantiate(sliderPrefabH, transform.position, Quaternion.identity) as GameObject;
        slidH.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        healthSlider = slidH.GetComponentInChildren<Slider>();
        healthTrans = slidH.GetComponent<RectTransform>();
        ragdollUtility = GetComponentInChildren<RagdollUtility>();
		fbbik = GetComponent<FullBodyBipedIK>();
        capsul =GetComponent<CapsuleCollider>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //substractOnce = false;
        dark = GameObject.FindGameObjectWithTag("Dark").GetComponent<DarkCity>();      
    }
    void Update ()
    {
		
        healthSlider.value = healthE;
		if (healthSlider.value >=  lookHealth || healthSlider.value <= 0)
			healthSlider.gameObject.SetActive (false);
		else
			healthSlider.gameObject.SetActive (true);
		Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
        healthTrans.transform.position = screenPoint;

        if (deal)
        {
            anim.SetBool("SpecialDamage1", true);
            rot.enabled = false;
            rot2.enabled = false;
            GetComponent<FullBodyBipedIK>().enabled = false;
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
           GetComponent<EnemyMili>().enabled = false;
        }
        if (dealDead)
        {
            healthE -= 300;
        }

        if (dealDamage)
        {
            if (substractOnce == false)
            {
                healthE -= 20;
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
                    capsul.GetComponent<CapsuleCollider>().enabled = false;
                    box.GetComponentInChildren<BoxCollider>().enabled = false;
                    GetComponent<EnemyMili>().enabled = false;
                    anim.enabled = false;
                    rot.enabled = false;
                    rot2.enabled = false;
                    RagdollHelper helper = GetComponent<RagdollHelper>();
                    helper.ragdolled = true;
                    GetComponent<RagdollHelper>().enabled = false;
                    GetComponent<FullBodyBipedIK>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                   // Destroy(gameObject, 5f);
                }
                if (GetComponent<EnemyRobotAI>())
                {
                    
                    capsul.GetComponent<CapsuleCollider>().enabled = false;
                    box.GetComponentInChildren<BoxCollider>().enabled = false;
                    GetComponent<EnemyRobotAI>().enabled = false;
                    anim.enabled = false;
                    RagdollHelper helper = GetComponent<RagdollHelper>();
                    helper.ragdolled = true;
                    GetComponent<RagdollHelper>().enabled = false;
                    GetComponent<FullBodyBipedIK>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

                    
                }
                if (GetComponent<EnemyRobotAISpawn>())
                {

                    capsul.GetComponent<CapsuleCollider>().enabled = false;
                    box.GetComponentInChildren<BoxCollider>().enabled = false;
                    GetComponent<EnemyRobotAISpawn>().enabled = false;
                    anim.enabled = false;
                    RagdollHelper helper = GetComponent<RagdollHelper>();
                    helper.ragdolled = true;
                    GetComponent<RagdollHelper>().enabled = false;
                    GetComponent<FullBodyBipedIK>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

                    
                }
                //if (GetComponent<EnemyAI>())
                //{
                //    anim.enabled = false;
                //    GetComponent<EnemyAI>().enabled = false;
                //    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

                ////   Destroy(gameObject, 5f);

                //}
                if (GetComponent<EnemyShootAi>())
                {
                    RagdollHelper helper = GetComponent<RagdollHelper>();
                    helper.ragdolled = true;
                    anim.enabled = false;
                    GetComponent<EnemyShootAi>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                  
                 //   Destroy(gameObject, 5f);

                }
                if (GetComponent<Boss>())
                {
                    capsul.GetComponent<CapsuleCollider>().enabled = false;
                    box.GetComponentInChildren<BoxCollider>().enabled = false;
                    GetComponent<Boss>().enabled = false;
                    anim.enabled = false;
                    RagdollHelper helper = GetComponent<RagdollHelper>();
                    helper.ragdolled = true;
                    GetComponent<RagdollHelper>().enabled = false;
                    GetComponent<FullBodyBipedIK>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                    dark.enabled = true;
                    //  Destroy(gameObject, 5f);
                }
                dead = true;
            }
          
        }
        if (ragdoll_state == true)
            ragdoll_time -= Time.deltaTime;
        if (ragdoll_time < 0 && ragdoll_state == true)
        {
            ragdoll_func_off();
            ragdoll_time = 1.5f;
        }
    }

	private void enableRagdoll(bool enabled)
	{
        if (!dead)
        {
            RagdollHelper helper = GetComponent<RagdollHelper>();
            helper.ragdolled = enabled;
            capsul.enabled = !enabled;
            agent.enabled = !enabled;
            //anim.enabled = !enabled;
            fbbik.enabled = !enabled;
            box.enabled = !enabled;
        }
      
    }

	public void ragdoll_func_on()
	{
		ragdoll_state = true;
		enableRagdoll (true);
	}

	public void ragdoll_func_off()
	{
		ragdoll_state = false;
		enableRagdoll (false);
	}

    public void checkToApply()
    {
        if (!deal)
        {
            deal = true;
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
    public void checkToApplyDead()
    {
        if (!dealDead)
        {
            dealDead = true;
        }
    }

    IEnumerator CloseDamage()
    {
        yield return damageT;
        dealDamage = false;
        substractOnce = false;

    }
}
