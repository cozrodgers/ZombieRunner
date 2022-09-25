using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }

    }
    public void TakeDamage(float dmg)
    {
        if (hitPoints > 0)
        {
            hitPoints -= dmg;
            Debug.Log(hitPoints);
        }
        else
        {
            //DIE

            return;
        }
    }

}
