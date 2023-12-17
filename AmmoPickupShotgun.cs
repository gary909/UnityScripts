using EmeraldAI.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

/// <summary> 
/// Ammo Pickup code: When a player walks into the shotgun ammo pickup the amount 
/// is increased by 5 (sending this amount back to the AmmoDispenser code).
/// </summary>

public class AmmoPickupShotgun: MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        AmmoDispenser ammoDispenser = FindObjectOfType<AmmoDispenser>(); // Access the AmmoDispenser instance
        int shotgunClips = ammoDispenser.CurrentShotgunShells;

        if (other.CompareTag("Player"))
        {
            if (shotgunClips >= 40) // If max amount of shotgun sheels clips (currently 40) reached, don't pick up
            {
                return;
            }
            else // Pickup pistol clip
            {
                //Debug.Log("You have this many shotgun sheels: " + shotgunClips);
                gameObject.GetComponent<MeshRenderer>().enabled = false; // Disable mesh renderer
                gameObject.GetComponent<Collider>().enabled = false; // Disable collider
                ammoDispenser.CurrentShotgunShells += 5; // Increase shotgun shells count by 5
            }
        }
    }
}