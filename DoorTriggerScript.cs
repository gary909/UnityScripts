using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorTriggerScript : MonoBehaviour
{

    public UnityEvent onPlayerEnterTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Entered");
            OnPlayerEnterTrigger();
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



