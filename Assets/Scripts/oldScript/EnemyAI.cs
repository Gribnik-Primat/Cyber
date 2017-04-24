﻿using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public float attackRate = 3;
    float attackR;
    public bool attacking;

	public float angleV = 180f;

    public float attackRange = 3;
    public float rotSpeed = 5;

    public GameObject damageCollider;

    Animator anim;

    UnityEngine.AI.NavMeshAgent agent;

    Transform target;
    CharacterStats CharStats;

	void Start ()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        CharStats = GetComponent<CharacterStats>();
        agent.stoppingDistance = attackRange;

        target = GameObject.FindGameObjectWithTag("Player").transform;
	}


    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < attackRange + .5f)
        {

            RaycastHit hit;
            Ray ray = new Ray(transform.position + Vector3.up, target.transform.position - transform.position);


            if (Physics.Raycast(ray, out hit, attackRange + .5f))
            {

                if (hit.transform.CompareTag("Player"))
                {
                    RaycastHit hit1;
                    Ray ray1 = new Ray(transform.position + Vector3.up, transform.forward + Vector3.up);


                    if (Physics.Raycast(ray1, out hit1, attackRange + .5f))
                    {

                        if (hit.transform.CompareTag("Player"))
                        {

                            attacking = true;

                        }

                    }
                }
            }
        }

        else
        {
            attacking = false;
        }
        if (!attacking)
        {
            agent.Resume();
            agent.SetDestination(target.position);

            Vector3 relativePosition = transform.InverseTransformDirection(agent.desiredVelocity);

            float hor = relativePosition.z;
            float ver = relativePosition.x;

            anim.SetFloat("Horizontal", hor, .6f, Time.deltaTime);
            anim.SetFloat("Vertical", ver, .6f, Time.deltaTime);


        }
        else
        {
            agent.Stop();
            Vector3 relativePosition = transform.InverseTransformDirection(agent.desiredVelocity);

            float hor = relativePosition.z;
            float ver = relativePosition.x;

            anim.SetFloat("Horizontal", hor, .6f, Time.deltaTime);
            anim.SetFloat("Vertical", ver, .6f, Time.deltaTime);

            attackR += Time.deltaTime;

            if (attackR > attackRate)
            {
                int rand = Random.Range(0, 4);
                switch (rand)
                {
                    case 0:
                        anim.SetBool("Attack", true);
                        StartCoroutine("CloseAttack");
                        attackR = 0;
                        break;
                    case 1:
                        anim.SetBool("AttackLL", true);
                        StartCoroutine("CloseAttack");
                        attackR = 0;
                        break;
                    case 2:
                        anim.SetBool("AttackRL", true);
                        StartCoroutine("CloseAttack");
                        attackR = 0;
                        break;
                    case 3:
                        anim.SetBool("AttackRH", true);
                        StartCoroutine("CloseAttack");
                        attackR = 0;
                        break;
                    case 4:
                        anim.SetBool("AttackKick", true);
                        StartCoroutine("CloseAttack");
                        attackR = 0;
                        break;
                }
            }


        }
    }

       
    
IEnumerator CloseAttack()
{
    yield return new WaitForSeconds(.4f);
    anim.SetBool("Attack", false);
    anim.SetBool("AttackRL", false);
    anim.SetBool("AttackLL", false);
    anim.SetBool("AttackRH", false);
    anim.SetBool("AttackKick", false);
}
public void OpenDamageCollider()
    {
        damageCollider.SetActive(true);
    }
    public void CloseDamageCollider()
    {
        damageCollider.SetActive(false);
    }
}