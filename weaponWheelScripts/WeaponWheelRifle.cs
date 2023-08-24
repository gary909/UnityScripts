using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWheelRifle : MonoBehaviour
{
    // Where you put the WeaponWheelSelectscript, (I put it on the TrackerAnchor)
    public GameObject weaponSelect;

    private void Equip()
    {
        weaponSelect.GetComponent<WeaponWheelSelect>().RifleSelect(); //edit
    }

    //did you hit enter the trigger cube with your hand? is so run Equip()
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "rightHand")
        {
            Equip();
        }
    }
}
