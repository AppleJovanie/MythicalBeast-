using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10;
    public GameObject bulletPrefab;
    public float shootCooldown = 4.0f; 
    private float lastShootTime;

    public GameObject panel;

    void Start()
    {
        lastShootTime = -shootCooldown;
    }


   public void Shoot()
    {
 

        if (Time.time - lastShootTime >= shootCooldown)
        {
            lastShootTime = Time.time;
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);

        }
    }
}
