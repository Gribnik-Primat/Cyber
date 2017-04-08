using UnityEngine;
using System.Collections.Generic;

public class DoExplodeDamageP : MonoBehaviour
{
    public bool damageEnemy = false;
    public bool damagePlayer = false;
    public float damage = 50.0f;

    List<CharacterStatsPlayer> targets = new List<CharacterStatsPlayer>();
    
    void OnTriggerEnter(Collider other)
    {
        CharacterStatsPlayer stats = other.GetComponent<CharacterStatsPlayer>();

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
        CharacterStatsPlayer stats = other.GetComponent<CharacterStatsPlayer>();

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
