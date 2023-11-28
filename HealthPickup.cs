// using UnityEngine;
// using EmeraldAI.Example;

// public class HealthPickup : MonoBehaviour
// {
//     public int healthAmount = 20; // The amount of health the pickup will provide

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             // Check if the player has the EmeraldAIPlayerHealth script attached
//             EmeraldAIPlayerHealth playerHealth = other.GetComponent<EmeraldAIPlayerHealth>();

//             if (playerHealth != null)
//             {
//                 // Increase the player's health
//                 playerHealth.CurrentHealth += healthAmount;

//                 // Destroy the health pickup after it has been collected
//                 Destroy(gameObject);
//             }
//             else
//             {
//                 Debug.LogError("EmeraldAIPlayerHealth script not found on the player GameObject.");
//             }
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmeraldAI.Example;
using EmeraldAI;
using UnityEngine.Events;

public class HealthPickup: MonoBehaviour
{

    public UnityEvent onPlayerEnterTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Entered");
            OnPlayerEnterTrigger();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    // Callback for onPlayerEnterTrigger
    public virtual void OnPlayerEnterTrigger()
    {

        // Call event
        if (onPlayerEnterTrigger != null)
        {
            onPlayerEnterTrigger.Invoke();
        }
    }



}
