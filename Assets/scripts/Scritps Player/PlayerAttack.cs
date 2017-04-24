using UnityEngine;
using System.Collections;
using RootMotion.Demos;
using RootMotion.FinalIK;

public class PlayerAttack : MonoBehaviour {

   
    Animator anim;
    public bool actionDamage;
    public float comboRate = .5f;
    public float comboSRate = 3f;

    [SerializeField] HitReaction hitReaction;
    [SerializeField] float hitForce = 1f;

    WaitForSeconds comboR;
    WaitForSeconds comboS;
    public GameObject  damageCollider_RH;
    bool DCR;
    public GameObject damageCollider_LH;
    bool DCL;
    public GameObject damageCollider_RL;
    bool DCRL;
    public GameObject damageCollider_LL;
    bool DCLL;
    public GameObject damageCollider_S;
    bool DCS;
    public GameObject damageCollider_SD;
    bool DCSD;

    private int rand;
	private int count = 0;

    public bool attack= false;
    float time = 0;
	float biostim;

    void Start ()
    {

        actionDamage = false;
        anim = GetComponent<Animator>();
       

        comboR = new WaitForSeconds(comboRate);
        comboS = new WaitForSeconds(comboSRate);

     DCR = false;
     DCL = false;
    DCRL = false;
    DCLL = false;
     DCS = false;
    DCSD = false;

    damageCollider_RH.SetActive(false);
        damageCollider_LH.SetActive(false);
        damageCollider_RL.SetActive(false);
        damageCollider_LL.SetActive(false);
        damageCollider_S.SetActive(false);
        damageCollider_SD.SetActive(false);

		biostim = GetComponentInParent<Biostim>().biostim;
    }


    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time > .5f)
        {
            if (DCR)
                damageCollider_RH.SetActive(false);
   
            if(DCL)
                damageCollider_LH.SetActive(false);

            if(DCRL)
                damageCollider_RL.SetActive(false);

            if(DCLL)
                damageCollider_LL.SetActive(false);

            if(DCS)
                damageCollider_S.SetActive(false);

            if(DCSD)
                damageCollider_SD.SetActive(false);

            time = 0;
        }

        //RaycastHit hit;
        //Ray ray = new Ray(transform.position + Vector3.up, transform.forward);     // об думать как сделать переход между слоями анимациив
        //if (Physics.Raycast(ray, out hit, 4f))
        //{

        //    if (hit.transform.CompareTag("Enemy"))
        //    {
        //        attack = true;
        //    }
        //}


        //if(CharStats.substractOnce ==false)
        //{
        //    
        //}
        //}
        //else
        //{
        //    time = time += Time.deltaTime;
        //    if (time >= 1f)
        //    {
        //        //anim.SetLayerWeight(1, 0.5f);

        //        //if (time >= 1.5f)
        //        //{
        //        anim.SetLayerWeight(1, 0f);
        //        time = 0;
        //        //}
        //    }
        //}

        
        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("Attack", true);
            StartCoroutine("CloseAttack");
           
        }
        if (Input.GetButton("Fire2"))
        {
            anim.SetBool("Attack2", true);   // вторая аттака
            StartCoroutine("CloseAttack1");
            
        }
        if(biostim >= 30) {
            if (actionDamage)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    anim.SetBool("SpecialAttack1", true);
                    StartCoroutine("CloseAttackSpecial");
                    GetComponentInParent<CharacterThirdPerson>().enabled = false;
                    actionDamage = false;
                    //  time += Time.deltaTime;
                }
                //if (time >= 4)
                //{
                //    StartCoroutine("CloseAttackSpecialDamage");
                //    time = 0;
                // }
            }
        }
    }
    IEnumerator CloseAttack()
    {    
        yield return comboR;
        anim.SetBool("Attack", false);
      
    }
    public void OpenDamageCollider_RH()
    { 	
        damageCollider_RH.SetActive(true);
        //RaycastHit hit = new RaycastHit();
        //Ray ray = new Ray(damageCollider_RH.transform.position, Vector3.forward);
        //if (Physics.Raycast(ray, out hit, 5f))
        //{   
        //    hitReaction.Hit(hit.collider, ray.direction * hitForce, hit.point);
        //}
    }
    public void CloseDamageCollider_RH()
    {
        DCR = true;
        damageCollider_RH.SetActive(false);
    }
    public void OpenDamageCollider_LH()
    {
        damageCollider_LH.SetActive(true);
        //RaycastHit hit = new RaycastHit();
        //Ray ray = new Ray(damageCollider_LH.transform.position, Vector3.forward);
        //if (Physics.Raycast(ray, out hit, 5f))
        //{
        //    hitReaction.Hit(hit.collider, ray.direction * hitForce, hit.point);
        //}

    }
    public void CloseDamageCollider_LH()

    {
        DCL = true;
        damageCollider_LH.SetActive(false);
    }
    IEnumerator CloseAttack1()
    {
        yield return comboR;
        anim.SetBool("Attack2", false);
    }
    public void OpenDamageCollider_RL()
    {
        damageCollider_RL.SetActive(true);
        //RaycastHit hit = new RaycastHit();
        //Ray ray = new Ray(damageCollider_RL.transform.position, Vector3.forward);
        //if (Physics.Raycast(ray, out hit, 5f))
        //{
        //    hitReaction.Hit(hit.collider, ray.direction * hitForce, hit.point);
        //}

    }
    public void CloseDamageCollider_RL()
    {
        DCRL = true;
        damageCollider_RL.SetActive(false);
    }
    public void OpenDamageCollider_LL()
    {
        damageCollider_LL.SetActive(true);
        //RaycastHit hit = new RaycastHit();
        //Ray ray = new Ray(damageCollider_LL.transform.position, Vector3.forward);
        //if (Physics.Raycast(ray, out hit, 5f))
        //{
        //    hitReaction.Hit(hit.collider, ray.direction * hitForce, hit.point);
        //}

    }
    public void CloseDamageCollider_LL()
    {
        DCLL = true;
        damageCollider_LL.SetActive(false);
    }
    IEnumerator CloseAttackSpecial()
    {
        yield return comboS;
        anim.SetBool("SpecialAttack1", false);
        GetComponentInParent<CharacterThirdPerson>().enabled = true;

    }
    public void OpenDamageCollider_S()
    {
        damageCollider_S.SetActive(true);


    }
    public void CloseDamageCollider_S()
    {
        DCS = true;
        damageCollider_S.SetActive(false);
		
    }
    //IEnumerator CloseAttackSpecialDamage()
    //{
    //    yield return comboR;
    //   // anim.SetBool("SpecialAttack1", false);

    //}
    public void OpenDamageCollider_SD()
    {
        damageCollider_SD.SetActive(true);


    }
    public void CloseDamageCollider_SD()
    {
        DCSD = true;
        damageCollider_SD.SetActive(false);
		
    }
    public void damage()
    {
        actionDamage = true;
    }

}
