using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;


    void Start()
    {
        SetWeaponActive();

    }
    void Update()
    {
        int prevWeapon = currentWeapon;
        ProcessKeyInput();
        ProcessScrollWheel();

        if (prevWeapon != currentWeapon)
        {
            
            SetWeaponActive();

        }

    }

    private void ProcessScrollWheel()
    {
        //access the scrollwheel axis
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            // if the index gets to end of available weapons, reset the index
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }

        }

    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentWeapon = 3;
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (currentWeapon == weaponIndex)
            {
    
                weapon.gameObject.SetActive(true);

            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }

    }


}

