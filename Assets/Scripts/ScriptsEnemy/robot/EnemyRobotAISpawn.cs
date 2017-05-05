using UnityEngine;
using System.Collections;
using UnityEngine;
using RootMotion.FinalIK;

public class EnemyRobotAISpawn : MonoBehaviour {


    UnityEngine.AI.NavMeshAgent agent;

    Animator anim;
    //public float visible = 10f; // дальность на сколько видим 
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

    Vector3 target_point;

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
        
        agent.stoppingDistance = attackRange;
        anim.SetLayerWeight(1, 0);
    }
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);

        agent.speed = speed * 2.5f;
        target_point = target.transform.position;
                        target_point.y = 0;

                        transform.LookAt(target);
                        if (distance < attackRange)           // расстоние меньше то бьем 
                        {
                            attacking = true;
                            
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
