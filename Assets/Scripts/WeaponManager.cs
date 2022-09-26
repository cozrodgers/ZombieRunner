using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Dictionary<int, GameObject> availableWeapons = new Dictionary<int, GameObject>();
    GameObject currentWeapon;
    public Dictionary<int, GameObject> AvailableWeapons
    {
        get { return availableWeapons; }
    }

    void Start()
    {

        Weapon[] weapons = GetComponentsInChildren<Weapon>();

        int weaponIndex = 0;
        foreach (Weapon weapon in weapons)
        {
            Transform _weapon = weapon.GetComponent<Transform>();
            _weapon.gameObject.SetActive(false);
            availableWeapons.Add(weaponIndex, _weapon.gameObject);
            Debug.Log(availableWeapons);
            weaponIndex++;
        }
     

        //Set first weapon to active
        Debug.Log(availableWeapons[1]);
        SetActiveWeapon(availableWeapons[1]);

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SetActiveWeapon(availableWeapons[0]);

        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SetActiveWeapon(availableWeapons[1]);

        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            SetActiveWeapon(availableWeapons[2]);

        }
    }
    public void SetActiveWeapon(GameObject weapon)
    {
        
        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(false);
        }
        currentWeapon = weapon;
        currentWeapon.gameObject.SetActive(true);
    }

}

