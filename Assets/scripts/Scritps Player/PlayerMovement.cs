using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Rigidbody rigid;
    Animator anim;
    PlayerInput plInput;
    CharacterController chart;

    public float speed = 15;
    public float jumpSpeedMultiplier = 3.0f;
    public float rotSpeed = 30;
    public bool canMove = true;
    Vector3 jump;
    bool lookLeft;

    AudioSource source;
    public AudioClip[] clips;

    //Quaternion originalRot;
    Quaternion targetRot;
    Vector3 velocity = new Vector3();
    bool wasSecondJump = false;
   
    void Start ()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.loop = false; 

        chart = GetComponent<CharacterController>();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        plInput = GetComponent<PlayerInput>();
    }
    
    void FixedUpdate()
    {
        if (chart.isGrounded)
        {
            // anim.enabled = true;
            if (canMove)
            {
                velocity.z = plInput.hotizontal;
                velocity.x = -plInput.vertical;
                velocity.y = 0;

                if (plInput.jump)
                {
                    wasSecondJump = false;
                    velocity.y = 1.0f;
                    velocity *= jumpSpeedMultiplier;
                }
                /*  if (!source.isPlaying)
                  {
                      RaycastHit hit;
                      if(Physics.Raycast(transform.position + Vector3.up,-Vector3.up,out hit, 2f))
                      {
                          if(hit.collider.material.name == "Metall(Instance)")
                          {
                              source.clip = clips[1];
                          }
                          else
                              source.clip = clips[0];
                      }

                  }*/

 //               source.Play();
                
               UpdateAnimator();

                if (plInput.hotizontal != 0)
                {
                    lookLeft = (plInput.hotizontal < -.01f) ? true : false;

                }
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
            else
            {
                velocity.z = 0;
                velocity.x = 0;
            }
        }
        else
        {
            // anim.enabled = false;
            if (plInput.jump && !wasSecondJump)
            {
                velocity.y = jumpSpeedMultiplier;
                wasSecondJump = true;
            }
        }

        velocity += Physics.gravity * Time.deltaTime;
        chart.Move(velocity * speed * Time.deltaTime);
    }

    void UpdateAnimator()
    {
        anim.SetFloat("Horizontal", Mathf.Abs(plInput.hotizontal));
        anim.SetFloat("Vertical", (lookLeft) ? -plInput.vertical : plInput.vertical);
    }
}
