using UnityEngine;
using System.Collections;

public class PlayerHack : MonoBehaviour
{

    PlayerInput plInput;
    PlayerMovement plMovement;
    public bool hack;
    Animator anim;
    public float see;
    Transform target;
    OpenClose open;

    void Start()
    {
        anim = GetComponent<Animator>();
        plMovement = GetComponent<PlayerMovement>();
        plInput = GetComponent<PlayerInput>();
        //GetComponent<EnemyRobotAI>().enabled = true;
        // GetComponent<RobotAI>().enabled = false;

    }


    void Update()
    {
       

        RaycastHit hit;
        Ray ray = new Ray(transform.position + Vector3.up, transform.forward);

        if (Physics.Raycast(ray, out hit, see))
        {
            
            if (hit.collider.CompareTag("Robot"))
            {
			if (Input.GetKeyDown(KeyCode.E))
                {
                    anim.SetBool("Uses", true);
                    plMovement.canMove = false;

                }
                else
                    anim.SetBool("Uses", false);
            }
        }

    

	}
    public void hacks()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position + Vector3.up, transform.forward);

        if (Physics.Raycast(ray, out hit, see))
        {

            hit.transform.SendMessage("Hack");
            }
        }
    }


    
    
