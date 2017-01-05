using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    bool exploding = false;
	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (exploding)
        {
            Vector3 v = transform.localScale;
            v.x += 0.2f;
            v.y += 0.2f;
            v.z += 0.2f;
            transform.localScale = v;

            if (v.y >= 6)
                Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (exploding)
            return;

        if (other.GetComponent<EnemyAI>() && other.GetComponent<CharacterStats>())
        {
            GetComponentInChildren<DoExplodeDamage>().explode();
            exploding = true;
        }
    }
}
