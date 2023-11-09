using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowEnemy : MonoBehaviour
{
    public float maxHealth = 100f;  // Maximum health of the enemy
    private float currentHealth;    // Current health of the enemy
    [SerializeField] FloatingHealthBar healthBar;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent <Rigidbody>();
        healthBar = GetComponent<FloatingHealthBar>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        //healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }
     
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //healthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();  // If the current health falls to or below zero, call the Die function
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    // Detect collisions with bullets
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("FireBullet")) // Assuming bullets are tagged as "Fire"
        {
            float damage = 10f; // The damage you want to apply
            TakeDamage(damage);
        }
        if (collision.collider.CompareTag("WaterBullet")) // Assuming bullets are tagged as "Fire"
        {
            float damage = 20f; // The damage you want to apply
            TakeDamage(damage);
        }
        if (collision.collider.CompareTag("HydrogenBullet")) // Assuming bullets are tagged as "Fire"
        {
            float damage = 20f; // The damage you want to apply
            TakeDamage(damage);
        }
    }
}
