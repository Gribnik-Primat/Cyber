/*using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

    public Transform target;
    float originalX;

	
	void Start ()
    {
        originalX = transform.position.x;
	}
	
	
	void Update ()
    {
        transform.position = new Vector3(originalX , target.position.y, target.position.z);
	}
}
*/