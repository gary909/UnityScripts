using EmeraldAI.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   A script to add to health pickups, once picked up the object is hidden from view and the amount of health is sent to the 'Player'.  
///   If player health >= 100 the pickup is ignored. The following is added in the player health script;
///   
///    void ApplyHeal(int heal)
///    {
///    CurrentHealth += heal; // add health points from healthPickup
///    UpdateHealth_UI_Text(); // upDate UI Text 
///    }   
/// </summary>

public class AmmoPickupPistol: MonoBehaviour
{
    public int healthAmount = 25;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject; // Find the player GameObject
            EmeraldAIPlayerHealth healthScript = player.GetComponent<EmeraldAIPlayerHealth>(); // Attempt to get the EmeraldAIPlayerHealth script on the player GameObject
            int currentHealth = healthScript.CurrentHealth; // Access CurrentHealth value in EmeraldAIPlayerHealth.cs
            //Debug.Log("Current Health: " + currentHealth);
            if (currentHealth >= 100) // If health >= 100 do nothing
            {
                return;
            } 
                else // Pickup health
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false; // Disable mesh renderer
                gameObject.GetComponent<Collider>().enabled = false; // Disable collider
                player.SendMessage("ApplyHeal", healthAmount); // Apply healing to the player
                // Debug.Log("Player picked up Health"); // Message to show working
            }
        }
    }
}

