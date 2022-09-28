using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterPickup : MonoBehaviour
{
    [SerializeField] float chargeAmount = 10f;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject)
            {
                Destroy(gameObject, 0.2f);

            }

            other.GetComponentInChildren<FlashlightSystem>().IncreaseBattery(chargeAmount);

        }
    }
}
