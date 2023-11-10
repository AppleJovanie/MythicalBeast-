using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Health : MonoBehaviour
{
    // Player's Life
    public float maxHealth = 100f;  // Maximum health of the enemy
    private float currentHealth;    // Current health of the enemy
    [SerializeField] FloatingHealthBar healthBar;
    Rigidbody rb;


    private float lastHitTime; // Time of the last hit

    public float hitCooldown = 4.0f; // Minimum cooldown between hits

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        healthBar = GetComponent<FloatingHealthBar>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        lastHitTime = -hitCooldown; // Initialize to allow immediate hit
    }

    public void TakeDamage(float damage)
    {

        if (Time.time - lastHitTime >= hitCooldown)
        {
            currentHealth -= damage;
            lastHitTime = Time.time;

            if (currentHealth <= 0)
            {
                Die();  // If the current health falls to or below zero, call the Die function
                Debug.Log("You won");           
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    // Players life
    // Detect collisions with bullets
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("FireBullet1")) // Assuming bullets are tagged as "Fire"
        {
            int damage = Random.Range(10, 20);
            TakeDamage(damage);
             collision.collider.CompareTag("Enemy");
            Debug.Log(damage);
        }
        if (collision.collider.CompareTag("WaterBullet1")) // Assuming bullets are tagged as "Water"
        {
            int damage = Random.Range(15, 25);
            TakeDamage(damage);
        }
        if (collision.collider.CompareTag("HydrogenBullet1")) // Assuming bullets are tagged as "Hydrogen"
        {
            int damage = Random.Range(9, 30);
            TakeDamage(damage);
        }
        if(maxHealth <= 0)
        {
            Debug.Log("You Lose");
        }
       
    }
   

}
