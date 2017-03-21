using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public float attackRate = 3;
    float attackR;
    bool attacking;

    public float attackRange = 3;
    public float rotSpeed = 5;

    public GameObject damageCollider;

    Animator anim;

    UnityEngine.AI.NavMeshAgent agent;

    Transform target;
    bool lookLeft;

	void Start ()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        agent.stoppingDistance = attackRange;

        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	
	void Update ()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < attackRange + .5f)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
            if (Physics.Raycast(ray, out hit, 2f))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    attacking = true;
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

            if(attackR> attackRate)
            {
                anim.SetBool("Attack", true);
                StartCoroutine("CloseAttack");

                attackR = 0;
            }
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
