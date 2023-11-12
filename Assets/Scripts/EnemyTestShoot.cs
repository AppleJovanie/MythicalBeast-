using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestShoot : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex;
    public GameObject[] guns;
    public GameObject weaponHolder;
    public GameObject currentGun;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10;

    public float shootingInterval = 5.0f; // Time interval between shots

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

        // Start automatically shooting with the specified interval
       
    }

    // Enemy Shooting triggered by collision
    private  void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("FireBullet"))
        {
            StartCoroutine(DelayedAction());
            
        }
    }

    // Enemy Shooting method
    private void ShootBullet()
    {
        var bullet = Instantiate(currentGun, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }

    private IEnumerator DelayedAction()
    {
       
        yield return new WaitForSeconds(2.0f);
        ShootBullet();
    }
}
