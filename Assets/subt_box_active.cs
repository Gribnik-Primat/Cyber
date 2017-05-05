using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subt_box_active : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		other.GetComponent<subtr> ().enter_the_subt_box = true;
	}
}
