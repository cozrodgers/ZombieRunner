using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hp = 100f;
    void Start()
    {

    }

    private void TriggerDeath()
    {
        GetComponent<DeathHandler>().HandleDeath();
    }

    public void TakeDamage(float dmg)
    {
        if (hp <= 0)
        {
            TriggerDeath();
        }
        else
        {
            hp -= dmg;
        }

    }
}
