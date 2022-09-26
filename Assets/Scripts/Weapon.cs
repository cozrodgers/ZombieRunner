using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] AudioClip fireSFX;
    [SerializeField] AudioClip emptySFX;
    [SerializeField] AudioClip rakeSFX;
    AudioSource audioSource;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Camera fPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] Ammo ammo;
    [SerializeField] float fireResetTime = 1f;
    [SerializeField] bool canFireWeapon = true;
    Animator anim;

    public Camera FPCamera { get { return fPCamera; } }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponentInParent<AudioSource>();
        fPCamera = Camera.main;
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammo.AmmoAmount > 0)
            {

                StartCoroutine(Shoot());
            }
            else
            {
                audioSource.PlayOneShot(emptySFX);
            }
        }

    }

    private IEnumerator Shoot()
    {

        //Check if animation state is idle
        if (canFireWeapon)
        {
            PlayRecoilAnimation();
            ammo.ReduceCurrentAmmo();
            PlayMuzzleFlash();
            PlayFireSFX();
            ProcessRaycast();
            canFireWeapon = false;

            yield return new WaitForSeconds(fireResetTime / 2);
            if (rakeSFX != null)
            {
                audioSource.PlayOneShot(rakeSFX);
            }
            yield return new WaitForSeconds(fireResetTime / 2);
            canFireWeapon = true;
        }

    }


    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
    private void PlayFireSFX()
    {
        audioSource.PlayOneShot(fireSFX);
    }
    private void PlayRecoilAnimation()
    {
        if (anim != null)
        {
            anim.SetTrigger("Recoil");
        }

    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(fPCamera.transform.position, fPCamera.transform.forward, out hit, range))
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
