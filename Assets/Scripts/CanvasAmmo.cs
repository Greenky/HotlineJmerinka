using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasAmmo : MonoBehaviour
{
    WeaponScript playerWeapon;
    public int currentAmmo;
    public int maxAmmo;
    public Text ammoText;
    public string ammo = "AMMO: ";
    void Start()
    {
        playerWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponScript>();
    }

    void Update()
    {
        if (playerWeapon._weaponInHand.sprite != null)
        {
            maxAmmo = playerWeapon._maxBullets;
            currentAmmo = playerWeapon._bulletsNum;
            if (maxAmmo != -1)
            {
                ammoText.text = ammo + currentAmmo.ToString() + " / " + maxAmmo.ToString();
                ammoText.enabled = true;
            }
            else
            {
                ammoText.text = string.Empty;
                ammoText.enabled = false;
            }
        }
        else
        {
            ammoText.text = string.Empty;
            ammoText.enabled = false;
        }

    }
}
