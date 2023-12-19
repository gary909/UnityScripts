using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to make objects constantly face player
// Better way of calling than once per frame??

public class FacePlayer : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }
}