using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    bool isDead;
    public bool IsDead { get { return isDead; } }

    public void TakeDamage(float dmg)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= dmg;
        if (hitPoints <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
    }

}
