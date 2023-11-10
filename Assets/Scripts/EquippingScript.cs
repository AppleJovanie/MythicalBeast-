using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippingScript : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex;
    public GameObject[] guns;
    public GameObject weaponHolder;
    public GameObject currentGun;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10;
    public float shootCooldown = 4.0f; // Cooldown time in seconds
    private float lastShootTime; // Last time the player shot

    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
        lastShootTime = -shootCooldown; // Initialize to allow immediate shooting
    }

    public void Prev()
    {
        if (currentWeaponIndex > 0)
        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex -= 1;
            guns[currentWeaponIndex].SetActive(true);
            currentGun = guns[currentWeaponIndex];
        }
    }

    public void Switch()
    {
        if (currentWeaponIndex < totalWeapons - 1)
        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex += 1;
            guns[currentWeaponIndex].SetActive(true);
            currentGun = guns[currentWeaponIndex];
        }
    }

    public void Shoot()
    {
        if (Time.time - lastShootTime >= shootCooldown)
        {
            lastShootTime = Time.time;
            var bullet = Instantiate(currentGun, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
  
}
