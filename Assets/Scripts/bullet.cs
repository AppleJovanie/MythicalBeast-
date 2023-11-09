using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float life = 5;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy")) // Assuming bullets are tagged as "Fire"
        {
            ThrowEnemy enemyHealth = collision.collider.GetComponent<ThrowEnemy>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1); // Reduce enemy health by 1
                Debug.Log("Enemy Hit, Health Reduced by 1");
            }
            else
            {
                Debug.LogError("Enemy object does not have an EnemyHealth component.");
            }
        }
    }
}
