using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootAi : MonoBehaviour {
    UnityEngine.AI.NavMeshAgent agent;

    Animator anim;
    public float visible = 10f; // дальность на сколько видим 
    GameObject Player;
    public float speed = 2f; // speed
    AudioSource sourse;
    public float angleV = 90f; // угол обозора

   
    bool attacking;

    
    public float rotSpeed = 5; // скокрость разворота 

    public Transform checkpoint;

    public GameObject damageCollider; // колайдер дамага
    bool lookLeft;

    public Transform point1;  // точка запуска райкаста для  выстрела 

    
    
    public AudioSource audio;

    Shoot shoot;

    Transform target;
    Transform target2;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();

        //<<<<<<< HEAD
        Invoke("move", 10f);

        /*sourse = GetComponent<AudioSource>();
        sourse.playOnAwake = false;
        sourse.loop = false;*/

        //=======


        //>>>>>>> origin/master
       
        agent.updateRotation = false;
    }

    void move()
    {
        CheckPoint point = checkpoint.GetComponent<CheckPoint>();
        checkpoint = point.getNext();
        agent.destination = checkpoint.position;
        Invoke("move", 10f);
    }
    void Update()
    {
        if (target != null)
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
                    Debug.DrawRay(transform.position + Vector3.up, Player.transform.position - transform.position * 100f);

                    if (Physics.Raycast(ray, out hit, visible))
                    {

                        if (hit.transform.gameObject == Player)
                        {
                            RaycastHit hit1;
                            Ray ray1 = new Ray(point1.position, Vector3.forward); // пускаем райкаст вперед
                            Debug.DrawRay(point1.position, Vector3.forward * 100f);
                            if (Physics.Raycast(ray1,out hit1, visible))  // на расстоние видимости
                            {
                                if(hit1.transform.gameObject == Player) // если попадаем, то атакуем
                                {
                                    attacking = true;
                                }
                                else
                                {
                                    attacking = false;
                                }

                            }
                          
                        }
                    }

                    if (!attacking)                     // если не бьем то идем
                    {

                        agent.Resume();
                        agent.SetDestination(target.position);

                        /*  Vector3 relativePosition = transform.InverseTransformDirection(agent.desiredVelocity);

                          float hor = relativePosition.z;
                          float ver = relativePosition.x;


                                      anim.SetFloat("Horizontal", hor, .6f, Time.deltaTime);  // анимамции в дереве смешиваний
                                      anim.SetFloat("Vertical", ver, .6f, Time.deltaTime);
                                  */

                        lookLeft = (target.position.z < transform.position.z) ? true : false;       // повороты

                        Quaternion targetRot = transform.rotation;

                        if (lookLeft)
                        {
                            targetRot = Quaternion.Euler(0, 180, 0);

                        }
                        else
                        {
                            targetRot = Quaternion.Euler(0, 0, 0);
                        }
                        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotSpeed); // плавность поворота

                    }
                    else
                    {
                            agent.Stop();
                            anim.SetBool("Attack", true);
                            StartCoroutine("CloseAttack");
                            shoot.shooting();
                    }
                }
            }
        }
        if (agent.velocity.magnitude > 0.5)   // запуск анимации
        {
            anim.SetBool("Walk", true);
        }
        else anim.SetBool("Walk", false);
        // move();
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
