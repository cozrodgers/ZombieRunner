using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour

{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Ammo ammo; 
    [SerializeField] AudioClip pickupSFX;

    void Start() {
        ammo = FindObjectOfType<Ammo>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(pickupSFX);
            ammo.IncreaseCurrentAmmo(ammoType, ammoAmount);
            Debug.Log("Picked Up");
            Destroy(this.gameObject);
        }
    }

}
