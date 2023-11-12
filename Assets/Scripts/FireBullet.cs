using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject Panel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Collided with the player");
            ShowPanel();
        }
    }

    private void ShowPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Panel not assigned in the inspector!");
        }
    }
}
