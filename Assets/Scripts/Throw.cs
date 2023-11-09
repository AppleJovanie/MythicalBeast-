using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{

    [Header("Reference")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectThrow;


    [Header("Settings")]
    public int totalThrow;
    public int throwCooldown;

    [Header("Throwing")]
    public KeyCode throwkey = KeyCode.Space;
    public float throwForce;
    public float throwUpwardForce;


    bool readyThrow;

    private void Start()
    {
        readyThrow = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(throwkey) && readyThrow && totalThrow > 0)
        {
            Throwing();
        }
    }
    private void Throwing()
    {
        readyThrow = false;

        GameObject projectile = Instantiate(objectThrow, attackPoint.position, cam.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;
        projectileRb.AddForce(forceAdd, ForceMode.Impulse);

        totalThrow--;

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyThrow = true;
    }

}
