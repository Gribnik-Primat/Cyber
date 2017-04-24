using UnityEngine;
using System.Collections;
using UnityEngine;
using RootMotion.FinalIK;

public class EnemyRobotAI : MonoBehaviour {


    UnityEngine.AI.NavMeshAgent agent;

    Animator anim;
    public float visible = 10f; // дальность на сколько видим 
    GameObject Player;
    public float speed = 2f; // speed
    AudioSource sourse;
    public float angleV = 180f; // угол обозора

    public float attackRate = 3; // скорость атаки
    float attackR;
    public bool attacking;

    public float attackRange = 3;// расстояние до цели
    public float rotSpeed = 5; // скокрость разворота 

  //  public Transform checkpoint;

    public GameObject damageCollider; // колайдер дамага
    bool DC;
    float time;

    public bool invisibleplayer;

    Transform target;
  
    float distance;

    void Start()
    {
        DC = false;
        time = 0;
        damageCollider.SetActive(false);
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        agent.speed = speed;
       
     //   Invoke("move", 18f);
        anim.SetLayerWeight(1, 1f);
        invisibleplayer = false;
        agent.stoppingDistance = attackRange;

    }
    //void move()
    //{

    //    CheckPoint point = checkpoint.GetComponent<CheckPoint>();
    //    checkpoint = point.getNext();
    //    agent.destination = checkpoint.position;
    //    Invoke("move", 18f);
    //}

    void Update()
    {  
        distance = Vector3.Distance(transform.position, target.position);
        if (distance < visible)
        {
            anim.SetLayerWeight(1, 0f);
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
                        agent.speed = speed * 2.5f;
                        
                        if (distance < attackRange)           // расстоние меньше то бьем 
                        {
                            attacking = true;
                            transform.LookAt(target);
                        }
                        else
                        {
                            attacking = false;
                        }
                        if (!attacking)
                        {                     // если не бьем то идем
                            agent.Resume();
                            agent.destination = Player.transform.position;
                           
                        }
                       

                        if (attacking)
                        {
                            agent.Stop();
                            attackR += Time.deltaTime;

                            if (attackR > attackRate)                       // атакуем 
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
                    else
                        agent.speed = speed;
                } 
            }
        }
        else
            anim.SetLayerWeight(1, 1f);
        if (distance < visible *0.25)
        {
            agent.speed = speed * 1.5f;
        }
        if (agent.velocity.magnitude > 1f && agent.velocity.magnitude < 5f)   // запуск анимации
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Run", false);
        }
        if (agent.velocity.magnitude > 5f)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Walk", false);
        }
        if (agent.velocity.magnitude < 1f)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Walk", false);
        }
        time += Time.deltaTime;
        if (time > 0.5f)
        {
            if (DC)
            {
                damageCollider.SetActive(false);
            }
            time = 0;
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
        DC = true;
        damageCollider.SetActive(false);
    }
}
