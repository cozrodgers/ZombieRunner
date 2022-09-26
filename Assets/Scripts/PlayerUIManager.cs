using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] TMP_Text ammoText;
    [SerializeField] Ammo ammo;
    void Start()
    {
        ammo = FindObjectOfType<Ammo>();


    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmo();

    }
    void UpdateAmmo()
    {
        ammoText.text = $"Ammo:{ammo.AmmoAmount}";

    }
}
