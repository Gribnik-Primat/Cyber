using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Rigidbody rigid;
    Animator anim;
    PlayerInput plInput;
    CharacterController chart;

    public float speed = 15;
    public float rotSpeed = 30;
    public bool canMove = true;
    Vector3 jump;
    bool lookLeft;

    AudioSource source;
    public AudioClip[] clips;

    //Quaternion originalRot;
    Quaternion targetRot;

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

                Vector3 horizontalForse = Vector3.forward* plInput.hotizontal;
                Vector3 verticalForce = -Vector3.right * plInput.vertical;
                // rigid.AddForce((horizontalForse + verticalForce).normalized * speed)
                chart.Move(horizontalForse * speed * Time.deltaTime);
                chart.Move(verticalForce * speed * Time.deltaTime);
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
                
                source.Play();

                if(plInput.jump)
                chart.Move(Vector3.up);

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
        }
         else
        {
           // anim.enabled = false;
                } 
        chart.Move(Physics.gravity * Time.deltaTime);
    }

    void UpdateAnimator()
    {
        anim.SetFloat("Horizontal", Mathf.Abs(plInput.hotizontal));
        anim.SetFloat("Vertical", (lookLeft) ? -plInput.vertical : plInput.vertical);
    }
}
