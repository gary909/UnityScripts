using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script to add to health pickups, once picked up
/// the object is hidden from view and the amount of 
/// health is sent to the 'Player'.  The following is added
/// in the player health script;
/// 
///    void ApplyHeal(int heal)
///    {
///    CurrentHealth += heal; // add health points from healthPickup
///    UpdateHealth_UI_Text(); // upDate UI Text 
///    }
///    
/// </summary>

public class HealthPickup: MonoBehaviour
{
    public int healthAmount = 25;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            //Destroy(gameObject); // Too slow, removed
            gameObject.GetComponent<MeshRenderer>().enabled = false; // Disable mesh renderer to look like its been picked up
            gameObject.GetComponent<Collider>().enabled = false; // Disable mesh Collider once it's been picked up
            other.transform.SendMessage("ApplyHeal", healthAmount);
            //Debug.Log("Player picked up Health"); // Message to show working
        }
    }
}

