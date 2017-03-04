using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameActive : MonoBehaviour {

	Sprite mGame;
	RectTransform miniGame;
	public GameObject crackPref;
	public bool active;

	void Start () 
	{
		active = false;
	}
	



	void Update ()
	{
		if (active) {
			//GameObject crack = Instantiate (crackPref, transform.position, Quaternion.identity) as GameObject;
		//	crack.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform);

			active = false;
		}
	}

		void OnTriggerStay(Collider other)
		{
			if (other.GetComponent<PlayerInput>())
			{
				if (Input.GetKey(KeyCode.E))
				{
					active = true;
				}
			}
		}
}
