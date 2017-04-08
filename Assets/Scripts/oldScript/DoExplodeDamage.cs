using UnityEngine;
using System.Collections.Generic;

public class DoExplodeDamage : MonoBehaviour
{
    public bool damageEnemy = false;
    public bool damagePlayer = false;
    public float damage = 50.0f;

    List<CharacterStats> targets = new List<CharacterStats>();
    
    void OnTriggerEnter(Collider other)
    {
        CharacterStats stats = other.GetComponent<CharacterStats>();

        if (!stats)
            return;

        bool relationOk = damageEnemy && other.GetComponent<EnemyAI>();
        relationOk = relationOk || (damagePlayer && other.GetComponent<PlayerTrap>());

        if (relationOk)
        {
            if (!targets.Contains(stats))
                targets.Add(stats);
        }
    }

    void OnTriggerExit(Collider other)
    {
        CharacterStats stats = other.GetComponent<CharacterStats>();

        if (!stats)
            return;

        if (targets.Contains(stats))
            targets.Remove(stats);
    }

    public void explode()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].damage(damage);
        }
    }
}
