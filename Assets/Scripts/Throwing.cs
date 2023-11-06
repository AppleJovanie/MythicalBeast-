using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    [Header("Reference")]
    public Transform attackPoint;
    public GameObject objectThrow;

    [Header("Settings")]
    public int totalThrow;
    public int throwCooldown;

    [Header("Throwing")]
    public KeyCode throwkey = KeyCode.Space;
    public Vector3 throwDirection = Vector3.forward; // Specify your desired throw direction
    public float throwForce;
    public float throwUpwardForce;
    private Animator anim;


    bool readyThrow;

    private void Start()
    {
        readyThrow = true;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(throwkey) && readyThrow && totalThrow > 0)
        {
            Throw();
        }
    }

    private void Throw()
    {
        
        readyThrow = false;

        GameObject projectile = Instantiate(objectThrow, attackPoint.position, Quaternion.identity);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // Apply force in the direction specified by throwDirection
        projectileRb.AddForce(throwDirection.normalized * throwForce, ForceMode.Impulse);

        totalThrow--;

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyThrow = true;
    }
}
