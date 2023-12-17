using EmeraldAI.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

/// <summary> 
/// Ammo Pickup code: When a player walks into the pistol ammo pickup the amount 
/// is increased by one (sending this amount back to the AmmoDispenser code).
/// </summary>

public class AmmoPickupPistol: MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Access the AmmoDispenser instance
        AmmoDispenser ammoDispenser = FindObjectOfType<AmmoDispenser>();
        int pistolClips = ammoDispenser.CurrentPistolClips;

        if (other.CompareTag("Player"))
        {
            if (pistolClips >= 10) // If max amount of pistol clips reached, don't pick up
            {
                return;
            }
            else // Pickup pistol clip
            {
                ammoDispenser.CurrentPistolClips += 1; // Increase pistol clips count by 1
                Debug.Log("You have this many pistol clips: " + pistolClips);
                gameObject.GetComponent<MeshRenderer>().enabled = false; // Disable mesh renderer
                gameObject.GetComponent<Collider>().enabled = false; // Disable collider
            }
        }
    }
}
