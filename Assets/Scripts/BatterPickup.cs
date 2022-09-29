using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterPickup : MonoBehaviour
{
    [SerializeField] float chargeAmount = 10f;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip chargeSFX;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource = other.GetComponent<AudioSource>();

            if (gameObject)
            {
                Destroy(gameObject, 0.2f);
            }

            other.GetComponentInChildren<FlashlightSystem>().IncreaseBattery(chargeAmount);
        }
    }

    void PlayChargeSFX()
    {
       audioSource.PlayOneShot(chargeSFX);
    }


}
