using UnityEngine;
using System.Collections;

public class EnemyRobotAI : MonoBehaviour {

    public float attackRate = 3; 
    float attackR;
    bool attacking;

    public float attackRange = 3; //attack radius
    public float rotSpeed = 5;// speed of rotation on 180

    public GameObject damageCollider;

    Animator anim;

    NavMeshAgent agent;

    Transform target;
    bool lookLeft;//change orientation to left

	void Start ()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        agent.stoppingDistance = attackRange;//stop ai if we in radius of attack
        agent.updateRotation = false;
     
        target = GameObject.FindGameObjectWithTag("Player").transform;
      
	}


    void Update()
    {

        float distance = Vector3.Distance(transform.position, target.position);//calculate distance to player

        if (GetComponent<CharacterStats>().health == 100)//this shit for our robot
        {
            GetComponent<StelsAI>().visible = 0f;//if health == 100 does nothing at all
        }
        else
        {
            if (distance < attackRange + .5f)//if for attacking player
            {
                attacking = true;
            }
            else
            {
                attacking = false;
            }
            if (!attacking)//if dont attack
            {
                agent.Resume();
                agent.SetDestination(target.position);

                Vector3 relativePosition = transform.InverseTransformDirection(agent.desiredVelocity);

                float hor = relativePosition.z;
                float ver = relativePosition.x;

                anim.SetFloat("Horizontal", hor, .6f, Time.deltaTime); //moving enemy?????@@@
                anim.SetFloat("Vertical", ver, .6f, Time.deltaTime);//moving enemy?????@@@

                lookLeft = (target.position.z < transform.position.z) ? true : false; // turn at 180 if player on the left side of enemy

                Quaternion targetRot = transform.rotation;

                if (lookLeft)
                {
                    targetRot = Quaternion.Euler(0, 180, 0);

                }
                else
                {
                    targetRot = Quaternion.Euler(0, 0, 0);
                }
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotSpeed);

            }
            else // if in radius
            {
                agent.Stop();
                Vector3 relativePosition = transform.InverseTransformDirection(agent.desiredVelocity);

                float hor = relativePosition.z;
                float ver = relativePosition.x;

                anim.SetFloat("Horizontal", hor, .6f, Time.deltaTime);//moving enemy?????@@@
                anim.SetFloat("Vertical", ver, .6f, Time.deltaTime);//moving enemy?????@@@

                attackR += Time.deltaTime;

                if (attackR > attackRate) // attack once in "attackRate" seconds
                {
                    anim.SetBool("Attack", true);
                    StartCoroutine("CloseAttack");

                    attackR = 0;
                }
            }
        }
    }
    public void Hack()
    {
        GetComponent<RobotAI>().enabled = true;
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
