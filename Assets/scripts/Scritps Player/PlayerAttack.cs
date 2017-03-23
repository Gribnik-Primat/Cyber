using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

   // PlayerInput plInput;
   // PlayerMovement plMovement;
    Animator anim;

    public float comboRate = .5f;

    WaitForSeconds comboR;
    public GameObject  damageCollider;
    public GameObject damageCollider1;



    void Start ()
    {
       // plInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
     //   plMovement = GetComponent<PlayerMovement>();

        comboR = new WaitForSeconds(comboRate);

        damageCollider.SetActive(false);
        damageCollider1.SetActive(false);
    }
	
	
	void FixedUpdate ()
    {
		if (Input.GetMouseButton(0))
        {   
            anim.SetBool("Attack", true);
           // plMovement.canMove = false;
            StartCoroutine("CloseAttack");
        }
		if (Input.GetMouseButton(1))
        {
            anim.SetBool("Attack2", true);   // вторая аттака
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
