﻿using UnityEngine;
using System.Collections;

public class StelsAI : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent agent;
    
    Animator anim;
    public float visible = 10f; // дальность на сколько видим 
    GameObject Player;
    public float speed = 2f; // speed
    AudioSource sourse;
    public float angleV = 70f; // угол обозора

    public float attackRate = 3; // скорость атаки
    float attackR;
    bool attacking;

    public float attackRange = 3;// расстояние до цели
    public float rotSpeed = 5; // скокрость разворота 

    public Transform checkpoint;

    public GameObject damageCollider; // колайдер дамага
    bool lookLeft;

    

    Transform target;
    Transform target2;
    void Start ()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();


        Invoke("move", 10f);

        agent.stoppingDistance = attackRange;
       // agent.updateRotation = false;
    }

    void move()
    {
        CheckPoint point = checkpoint.GetComponent<CheckPoint>();
        checkpoint = point.getNext();
        agent.destination = checkpoint.position;
        Invoke("move", 20f);
    }
        void Update()
    {
        if (target != null )
        {
            float distance = Vector3.Distance(transform.position, target.position);  // дистанция
           if (distance < visible)
           {
                Quaternion look = Quaternion.LookRotation(target.transform.position - transform.position);  // угол видимости
                float angle = Quaternion.Angle(transform.rotation, look);
                if (angle < angleV)
                {
                    RaycastHit hit;
                    Ray ray = new Ray(transform.position + Vector3.up, Player.transform.position - transform.position); //  райкаст чтоб не палил нас сковзь стены


                    if (Physics.Raycast(ray, out hit, visible))
                    {

                        if (hit.transform.CompareTag("Player"))
                        {
                            if (distance < attackRange)           // расстоние меньше то бьем 
                            {

                                attacking = true;
                            }
                            else
                            {
                                attacking = false;
                            }
                        }
                        if (!attacking)                     // если не бьем то идем
                        {
                            agent.Resume();
                            agent.destination = Player.transform.position;

                            //lookLeft = (target.position.z < transform.position.z) ? true : false;       // повороты

                            //Quaternion targetRot = transform.rotation;

                            //if (lookLeft)
                            //{
                            //    targetRot = Quaternion.Euler(0, 180, 0);

                            //}
                            //else
                            //{
                            //    targetRot = Quaternion.Euler(0, 0, 0);
                            //}
                            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotSpeed); // плавность поворота

                        }
                        else
                        {
                            agent.Stop();
                            attackR += Time.deltaTime;

                            if (attackR > attackRate)                       // атакуем 
                            {
                                anim.SetBool("Attack", true);
                                StartCoroutine("CloseAttack");

                                attackR = 0;
                            }
          
                        }
                    }
                }
            }
      }
        if (agent.velocity.magnitude > 0.1)   // запуск анимации
        {
            anim.SetBool("Walk", true);
        }
        else anim.SetBool("Walk", false);
        
    }
    
    IEnumerator CloseAttack()
    {
        yield return new WaitForSeconds(.4f);
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
}
           
        
    

