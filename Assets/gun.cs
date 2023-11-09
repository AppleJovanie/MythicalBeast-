using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10;
    
    public GameObject currentGun;
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to the input button you want to use
        {
            Shoot();
        }
    }

   public void Shoot()
    {
        if (currentGun != null)
        {
            GameObject bullet = Instantiate(currentGun, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;
            }
            else
            {
                Debug.LogError("The currentGun prefab doesn't have a Rigidbody component.");
                Destroy(bullet);
            }

        }
    }
}
