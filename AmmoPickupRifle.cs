using EmeraldAI.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

/// <summary> 
/// Ammo Pickup code: When a player walks into the rifle ammo pickup the amount 
/// is increased by one (sending this amount back to the AmmoDispenser code).
/// </summary>

public class AmmoPickupRifle: MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        AmmoDispenser ammoDispenser = FindObjectOfType<AmmoDispenser>(); // Access the AmmoDispenser instance
        int rifleClips = ammoDispenser.CurrentRifleClips;

        if (other.CompareTag("Player"))
        {
            if (rifleClips >= 40) // If max amount of rifle clips (currently 400) reached, don't pick up
            {
                return;
            }
            else // Pickup pistol clip
            {
                //Debug.Log("You have this many rifle clips: " + rifleClips);
                gameObject.GetComponent<MeshRenderer>().enabled = false; // Disable mesh renderer
                gameObject.GetComponent<Collider>().enabled = false; // Disable collider
                ammoDispenser.CurrentRifleClips += 1; // Increase pistol clips count by 1
            }
        }
    }
}

