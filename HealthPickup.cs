using UnityEngine;
using EmeraldAI.Example;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 20; // The amount of health the pickup will provide

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the player has the EmeraldAIPlayerHealth script attached
            EmeraldAIPlayerHealth playerHealth = other.GetComponent<EmeraldAIPlayerHealth>();

            if (playerHealth != null)
            {
                // Increase the player's health
                playerHealth.CurrentHealth += healthAmount;

                // Destroy the health pickup after it has been collected
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("EmeraldAIPlayerHealth script not found on the player GameObject.");
            }
        }
    }
}
