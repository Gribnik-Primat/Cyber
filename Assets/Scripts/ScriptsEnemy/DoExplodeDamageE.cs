using UnityEngine;
using System.Collections.Generic;

public class DoExplodeDamageE : MonoBehaviour
{
    public bool damageEnemy = false;
    public bool damagePlayer = false;
    public float damage = 50.0f;

    List<CharacterStatsEnemy> targets = new List<CharacterStatsEnemy>();
    
    void OnTriggerEnter(Collider other)
    {
        CharacterStatsEnemy stats = other.GetComponent<CharacterStatsEnemy>();

        if (!stats)
            return;

        bool relationOk = damageEnemy && other.GetComponent<EnemyMili>();
        relationOk = relationOk || (damagePlayer && other.GetComponent<PlayerTrap>());

        if (relationOk)
        {
            if (!targets.Contains(stats))
                targets.Add(stats);
        }
    }

    void OnTriggerExit(Collider other)
    {
        CharacterStatsEnemy stats = other.GetComponent<CharacterStatsEnemy>();

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
