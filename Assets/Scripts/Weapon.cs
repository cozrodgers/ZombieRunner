using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float damage = 30f;
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }
    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {

            Debug.Log("I hit this thing" + hit.transform.name);
            //TODO add hit FX
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
            {

                target.TakeDamage(damage);
            }
            // decrease enemy health
        }
        else
        {
            return;
        }

    }
}
