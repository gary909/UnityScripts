using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaisingPlatformTriggerScript : MonoBehaviour
{

    public UnityEvent onPlayerEnterTrigger;
    public UnityEvent onPlayerExitTrigger;

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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Exited");
            OnPlayerExitTrigger();
        }
    }

    // Callback for onPlayerEnterTrigger
    public virtual void OnPlayerExitTrigger()
    {

        // Call event
        if (onPlayerEnterTrigger != null)
        {
            onPlayerEnterTrigger.Invoke();
        }
    }


}



