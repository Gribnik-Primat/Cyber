using UnityEngine;
using System.Collections;
using RootMotion.Demos;

public class PlayerAttack : MonoBehaviour {

    // PlayerInput plInput;
    // PlayerMovement plMovement;
    Animator anim;

    public float comboRate = .5f;
    HitReactionTrigger hitt;
    WaitForSeconds comboR;
    public GameObject  damageCollider_RH;
    public GameObject damageCollider_LH;
    public GameObject damageCollider_RL;
    public GameObject damageCollider_LL;
    private float turnspeed;
    public bool attack= false;
    public float time = 0;
    CharacterStats CharStats;

    void Start ()
    {
        CharStats = GetComponent<CharacterStats>();

        // plInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
        //   plMovement = GetComponent<PlayerMovement>();
        turnspeed = GetComponentInParent<CharacterThirdPerson>().turnSpeed;

        comboR = new WaitForSeconds(comboRate);
        hitt = GetComponent<HitReactionTrigger>();

        damageCollider_RH.SetActive(false);
        damageCollider_LH.SetActive(false);
        damageCollider_RL.SetActive(false);
        damageCollider_LL.SetActive(false);
    }


    void FixedUpdate()
    {

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
           // turnspeed = 0;
            StartCoroutine("CloseAttack");
           
        }
        if (Input.GetButton("Fire2"))
        {
            anim.SetBool("Attack2", true);   // вторая аттака
           // turnspeed = 0;
            StartCoroutine("CloseAttack1");
            
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
        

    }
    public void CloseDamageCollider_RH()
    {
        damageCollider_RH.SetActive(false);
        
    }
    public void OpenDamageCollider_LH()
    {
        damageCollider_LH.SetActive(true);


    }
    public void CloseDamageCollider_LH()
    {
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


    }
    public void CloseDamageCollider_RL()
    {
        damageCollider_RL.SetActive(false);

    }
    public void OpenDamageCollider_LL()
    {
        damageCollider_LL.SetActive(true);


    }
    public void CloseDamageCollider_LL()
    {
        damageCollider_LL.SetActive(false);

    }

}
