using EmeraldAI.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

/// <summary> 
/// </summary>

public class AmmoPickupPistol: MonoBehaviour
{
    
    private void Start()
    {
        int pistolClips = FindObjectOfType<AmmoDispenser>().CurrentPistolClips;
    }


    void OnTriggerEnter(Collider other)
    {
        int pistolClips = FindObjectOfType<AmmoDispenser>().CurrentPistolClips;
        if (other.CompareTag("Player"))
        {
            
            if (pistolClips >= 10) // If max amount of pistol clips reached, don't pick up, 
            {
                return;
            }
            else // Pickup health
            {
                Debug.Log( "You have this many pistol clips: " + pistolClips);
                gameObject.GetComponent<MeshRenderer>().enabled = false; // Disable mesh renderer
                gameObject.GetComponent<Collider>().enabled = false; // Disable collider
                //player.SendMessage("ApplyArmourMega", armourAmount); // Apply armour to the player
            }
        }
    }

}

