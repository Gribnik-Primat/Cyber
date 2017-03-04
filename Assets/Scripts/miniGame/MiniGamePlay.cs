using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePlay : MonoBehaviour {
	
	public GameObject Trigger;
	public GameObject Key;
	public Transform point;
	public bool acktiveKey;

	public float OpenX;
	public float OpenY;
	public float OpenZ;
	public float CloseX;
	public float CloseY;
	public float CloseZ;

	Animator anim;
	AudioSource audio;

	void Start () 
	{
		anim = GetComponent<Animator> ();
		audio=GetComponent<AudioSource>();

	}

	void Update () 
	{
		RaycastHit hit;
		Ray ray = new Ray (Trigger.transform.position, point.position);
		if (Physics.Raycast(ray, out hit, 100f))
			{
				if (hit.transform.CompareTag("Key"))
				{
				if(Input.GetMouseButtonDown(0))
					{
					acktiveKey = true;
					}
				}
	        }

		if(acktiveKey)
		{
			Vector2 toPosition = new Vector2(OpenX, OpenY);

			Key.transform.position = Vector3.Lerp(transform.position, toPosition, 4f * Time.deltaTime);
		}
		else
		{
			Vector2 toPosition1 = new Vector2(CloseX,CloseY);

			Key.transform.position = Vector2.Lerp(transform.position, toPosition1, 4f * Time.deltaTime);
		} 
	}
}
