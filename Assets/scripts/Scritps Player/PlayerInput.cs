using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    public float hotizontal;
    public float vertical;
    public bool jump;
    public bool fire1;
    public bool fire2;
    public bool uses;
    public bool trapping;

	void Start ()
    {
	
	}
	
	
	void FixedUpdate ()
    {
        
        this.hotizontal = Input.GetAxis("Horizontal");
        this.vertical = Input.GetAxis("Vertical");
        this.fire1 = Input.GetButton("Fire1");
        this.uses = Input.GetButton("Uses");
        this.jump = Input.GetButtonDown("Jump");
        this.trapping = Input.GetKeyDown(KeyCode.T);
        this.fire2 = Input.GetButton("Fire2");
    }
}
