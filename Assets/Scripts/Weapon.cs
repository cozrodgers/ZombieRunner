using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] AudioClip fireSFX;
    AudioSource audioSource;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    
    }
    private void Shoot()
    {
        PlayMuzzleFlash();
        PlayFireSFX();
        ProcessRaycast();

    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
    private void PlayFireSFX()
    {
        audioSource.PlayOneShot(fireSFX);
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);

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

    private void CreateHitImpact(RaycastHit hit)
    {

        GameObject fx = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(fx, 0.2f);

    }
    private void AimDownSight()
    {
        GetComponent<WeaponZoom>().ToggleZoom();
    }
}
