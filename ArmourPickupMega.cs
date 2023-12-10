using EmeraldAI.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   A script to add to MegaArmour pickups(200hp) or 1hp mini pickups, once picked up,is hidden and the amount of armour is sent to the 'Player'.  
///   If player armour >= 200 the pickup is ignored. The following is added in the player armour script;
///   
///    void ApplyMegaArmour(int ArmrAmnt)
///    {
///    CurrentArmourh += ArmrAmnt; // add health points from healthPickup
///    UpdateArmour_UI_Text(); // upDate UI Text 
///    }   
/// </summary>

public class ArmourPickupMega: MonoBehaviour
{
    public int armourAmount = 200;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject; // Find the player GameObject
            EmeraldAIPlayerHealth armourScript = player.GetComponent<EmeraldAIPlayerHealth>(); // Attempt to get the EmeraldAIPlayerHealth script on the player GameObject
            int currentArmour = armourScript.CurrentArmour; // Access CurrentArmour value in EmeraldAIPlayerHealth.cs
            //Debug.Log("Current Armour: " + currentArmour);
            if (currentArmour >= 200) // If armour >= 100 do nothing
            {
                return;
            } 
                else // Pickup health
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false; // Disable mesh renderer
                gameObject.GetComponent<Collider>().enabled = false; // Disable collider
                player.SendMessage("ApplyArmourMega", armourAmount); // Apply armour to the player
                // Debug.Log("Player picked up Armour"); // Message to show working
            }
        }
    }
}

