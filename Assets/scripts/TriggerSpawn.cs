using UnityEngine;
using System.Collections;

public class TriggerSpawn : MonoBehaviour
{

    GameManager gm;
    RotCam rc;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		rc = GetComponentInParent<RotCam> ();
    }

    void OnTriggerEnter(Collider other)
    {
        
		if (other.GetComponent<PlayerHack>())
        {
			rc.activeCam = true;
            gm.spawnEnemiesNow = true;
            Destroy(gameObject);

        }
    }
}
