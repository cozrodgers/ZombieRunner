using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] PlayerHealth target;
    [SerializeField] float dmg = 40f;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();

    }
    public void AttackHitEvent()
    {
        if (target == null)
        {
            return;
        }
        target.TakeDamage(dmg);
        Debug.Log($"Hit you for {dmg}");
    }
    void OnDamageTaken(){
        Debug.Log("success");
    }
}
