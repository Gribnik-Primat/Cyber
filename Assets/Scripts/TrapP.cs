using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapP : MonoBehaviour {
    public static int STATE_WAIT = 0;
    public static int STATE_SIGNAL = 1;
    public static int STATE_EXPLODING = 2;
    
    public bool triggeredByEnemy = false;
    public bool triggeredByPlayer = false;

    public bool damageEnemy = false;
    public bool damagePlayer = false;
    public float damage = 50.0f;

    public float timeInSignalState = 0.0f;

    int state = STATE_WAIT;
    float remainSignalTime;
    Blinking blink;
    float deltaScalePerSec = 15.0f;
    // Use this for initialization
    void Start ()
    {
        DoExplodeDamageP doDamage = GetComponentInChildren<DoExplodeDamageP>();
        doDamage.damageEnemy = damageEnemy;
        doDamage.damagePlayer = damagePlayer;
        doDamage.damage = damage;

        blink = GetComponentInChildren<Blinking>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (state == STATE_SIGNAL)
        {
            remainSignalTime -= Time.deltaTime;
            if (remainSignalTime <= 0)
            {
                state = STATE_EXPLODING;
                GetComponentInChildren<DoExplodeDamageP>().explode();
                GetComponentInChildren<Renderer>().material.color = Color.red;
            }
        }
        else if (state == STATE_EXPLODING)
        {
            Vector3 v = transform.localScale;
            v.x += deltaScalePerSec * Time.deltaTime;
            v.y += deltaScalePerSec * Time.deltaTime;
            v.z += deltaScalePerSec * Time.deltaTime;
            transform.localScale = v;
            deltaScalePerSec += 10.0f * Time.deltaTime;
            if (v.y >= 6)
                Destroy(gameObject);
        }

        blink.setRunning(state == STATE_SIGNAL);
    }

    void OnTriggerEnter(Collider other)
    {
        if (state == STATE_WAIT)
        {
            bool relationOk = triggeredByEnemy && other.GetComponent<EnemyAI>();
            relationOk = relationOk || (triggeredByPlayer && other.GetComponent<PlayerTrap>());

            if (relationOk && other.GetComponent<CharacterStatsPlayer>())
            {
                state = STATE_SIGNAL;
                remainSignalTime = timeInSignalState;
                GetComponentInChildren<Renderer>().material.color = Color.red;
            }
        }
    }
}
