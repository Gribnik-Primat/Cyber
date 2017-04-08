using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootAi : MonoBehaviour {
    UnityEngine.AI.NavMeshAgent agent;
    Shoot shoot;
    Animator anim;
    public float visible = 10f; // дальность на сколько видим 
    GameObject Player;
    public float speed = 2f; // speed
    AudioSource sourse;
    public float angleV = 70f; // угол обозора

    public float attackRate = 3; // скорость атаки
    float attackR;
    public bool attacking;

    public float attackRange = 8;// расстояние до цели
    public float rotSpeed = 5; // скокрость разворота 

    public Transform checkpoint;

    public GameObject damageCollider; // колайдер дамага

    // public bool invisibleplayer;

    CharacterStats CharStats;

    Transform target;
    public bool see;
    float distance;

    void Start()
    {
        see = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        anim.SetLayerWeight(1, 0f);
        CharStats = GetComponent<CharacterStats>();
        Invoke("move", 1f);
        shoot = GetComponentInChildren<Shoot>();
        // invisibleplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Invisibility>().state;
        // invisibleplayer = false;

        agent.stoppingDistance = attackRange;

    }
    void move()
    {
        CheckPoint point = checkpoint.GetComponent<CheckPoint>();
        checkpoint = point.getNext();
        agent.destination = checkpoint.position;
        Invoke("move", 15f);
    }

    void Update()
    {

        //@@@@@@@@@@@ какого хрена здесь вылетает ошибка NULL REFERENCE Exception?!!!
        float distance;   // дистанция
                          //if (invisibleplayer )
                          //// невидимость игрока
                          //	distance = visible+1;
                          //      if (invisibleplayer)
                          //      {

        distance = Vector3.Distance(transform.position, target.position);
        if (distance < visible)
        {
            Quaternion look = Quaternion.LookRotation(target.transform.position - transform.position);  // угол видимости
            float angle = Quaternion.Angle(transform.rotation, look);
            if (angle < angleV)
            {
                RaycastHit hit;
                Ray ray = new Ray(transform.position + Vector3.up, target.transform.position - transform.position); //  райкаст чтоб не палил нас сковзь стены


                if (Physics.Raycast(ray, out hit, visible))
                {

                    if (hit.transform.CompareTag("Player"))
                    {
                        see = true;

                        if (distance < attackRange)           // расстоние меньше то бьем 
                        {
                            anim.SetLayerWeight(1,1f);
                            attacking = true;

                        }
                        else
                        {
                            anim.SetLayerWeight(1, 0f);
                            attacking = false;

                        }



                        if (!attacking)
                        {                     // если не бьем то идем
                            anim.SetLayerWeight(1, 0f);
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

                        if (attacking)
                        {
                            agent.Stop();
                            attackR += Time.deltaTime;

                            if (attackR > attackRate)                       // атакуем 
                            {      
                               anim.SetBool("Attack", true);
                                shoot.shooting();
                               StartCoroutine("CloseAttack");
                               attackR = 0;  
                            }


                        }
                    }
                }
            }
        }
        // }

        if (agent.velocity.magnitude > 1)   // запуск анимации
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Run", false);
        }
        else if (agent.velocity.magnitude > 3)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Walk", false);
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }
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
