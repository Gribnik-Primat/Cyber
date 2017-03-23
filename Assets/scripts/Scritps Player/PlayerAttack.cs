using UnityEngine;
using System.Collections;
using RootMotion.Demos;

public class PlayerAttack : MonoBehaviour {

   // PlayerInput plInput;
   // PlayerMovement plMovement;
    Animator anim;

    public float comboRate = .5f;

    WaitForSeconds comboR;
    public GameObject  damageCollider;
    public GameObject damageCollider1;
    private float turnspeed;

    void Start ()
    {
       // plInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
        //   plMovement = GetComponent<PlayerMovement>();
        turnspeed = GetComponent<CharacterThirdPerson>().turnSpeed;

        comboR = new WaitForSeconds(comboRate);

        damageCollider.SetActive(false);
        damageCollider1.SetActive(false);
    }
	
	
	void FixedUpdate ()
    {
		if (Input.GetButton("Fire1"))
        {   
            anim.SetBool("Attack", true);
            turnspeed = 0;
           // plMovement.canMove = false;
            StartCoroutine("CloseAttack");
        }
		if (Input.GetButton("Fire2"))
        {
            anim.SetBool("Attack2", true);   // вторая аттака
            turnspeed = 0;
           // plMovement.canMove = false;
            StartCoroutine("CloseAttack1");
        }
    }
    IEnumerator CloseAttack()
    {
        yield return comboR;
        anim.SetBool("Attack", false);
      
    }
    public void OpenDamageCollider()
    {
        damageCollider.SetActive(true);
        

    }
    public void CloseDamageCollider()
    {
        damageCollider.SetActive(false);
        
    }
    IEnumerator CloseAttack1()
    {
        yield return comboR;
        anim.SetBool("Attack2", false);

    }
    public void OpenDamageCollider1()
    {
        damageCollider1.SetActive(true);


    }
    public void CloseDamageCollider1()
    {
        damageCollider1.SetActive(false);

    }
}
