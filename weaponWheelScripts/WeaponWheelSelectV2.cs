using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

// V2 includes code for Shotgun

public class WeaponWheelSelect : MonoBehaviour
{
    [Tooltip("The Grabber of hand you want this on, right or left")]
    public Grabber handGrabber;

    [Tooltip("The Weapon in the Hiarchy")]
    public Grabbable EquipGrabbableRifle;
    [Tooltip("The Gun in the Hiarchy enables and disables weapon")]
    public GameObject Rifle;
    [Tooltip("the trigger abject for weapon")]
    public GameObject RifleCubeOrigin;

    [Tooltip("The Weapon in the Hiarchy")]
    public Grabbable EquipGrabbablePistol;
    [Tooltip("The Gun in the Hiarchy enables and disables weapon")]
    public GameObject Pistol;
    [Tooltip("the trigger abject for weapon")]
    public GameObject PistolCubeOrigin;


    [Tooltip("The Weapon in the Hiarchy")]
    public Grabbable EquipGrabbableShotgun;
    [Tooltip("The Gun in the Hiarchy enables and disables weapon")]
    public GameObject Shotgun;
    [Tooltip("the trigger abject for weapon")]
    public GameObject ShotgunCubeOrigin;


    public void ShotgunSelect()
    {

        // check if shotgun is already being held, if so do nothing
        if (handGrabber.HeldGrabbable == EquipGrabbableShotgun)
        {
            return;
        }

        //check if the item being held is the pistol or rifle, if so drop it, return it to its origin and equip the rifle
        if (handGrabber.HeldGrabbable != null)
        {
            if (handGrabber.HeldGrabbable == EquipGrabbablePistol) // Check if holding Pistol
            {
                handGrabber.HeldGrabbable.DropItem(handGrabber); // drop the current weapon
                EquipGrabbablePistol.transform.position = PistolCubeOrigin.transform.position; //return to origin position
                EquipGrabbablePistol.transform.rotation = PistolCubeOrigin.transform.rotation; //rerurn to origin rotation

                EquipGrabbablePistol.GetComponent<Rigidbody>().isKinematic = true; // make kinematic so it doesn't fall to the ground
                Pistol.SetActive(false); // disable the pistol so it disappears
            }
            if (handGrabber.HeldGrabbable == EquipGrabbableRifle)  // Check if holding Rifle
            {
                handGrabber.HeldGrabbable.DropItem(handGrabber); // drop the rifle
                EquipGrabbableRifle.transform.position = RifleCubeOrigin.transform.position;
                EquipGrabbableRifle.transform.rotation = RifleCubeOrigin.transform.rotation;
                EquipGrabbableRifle.GetComponent<Rigidbody>().isKinematic = true;
                Rifle.SetActive(false);

            }

            Shotgun.SetActive(true); //enable the shotgun so it appears
            handGrabber.GrabGrabbable(EquipGrabbableShotgun); // equip the shotgun

            EquipGrabbableShotgun.GetComponent<Rigidbody>().isKinematic = false; // set kinematic to false

            EquipGrabbableShotgun.transform.SetParent(null); // set its parent to null so it doesn't disappear with the weapon wheel
        }
        //if nothing is being held, equip the shotgun
        else
        {
            Shotgun.SetActive(true); //enable shotgun so it appears
            handGrabber.GrabGrabbable(EquipGrabbableShotgun); // equip the shotgun

            EquipGrabbableShotgun.GetComponent<Rigidbody>().isKinematic = false; //  set kinematic to false

            EquipGrabbableShotgun.transform.SetParent(null); //  set its parent to null so it doesn't disappear
        }

    }


    public void RifleSelect()
    {

        // check if rifle is already being held, if so do nothing
        if (handGrabber.HeldGrabbable == EquipGrabbableRifle)
        {
            return;
        }

        //check if the item being held is the pistol or shotgun, if so drop it, return it to its orgin and equip the rifle
        if (handGrabber.HeldGrabbable != null)
        {
            if (handGrabber.HeldGrabbable == EquipGrabbablePistol) // Check if holding Pistol
            {
                handGrabber.HeldGrabbable.DropItem(handGrabber); // drop the rifle
                EquipGrabbablePistol.transform.position = PistolCubeOrigin.transform.position; //return to origin position
                EquipGrabbablePistol.transform.rotation = PistolCubeOrigin.transform.rotation; //rerurn to origin rotation

                EquipGrabbablePistol.GetComponent<Rigidbody>().isKinematic = true; // make kinematic so it doesn't fall to the ground
                Pistol.SetActive(false); // disable the pistol so it disappears
            }
            if (handGrabber.HeldGrabbable == EquipGrabbableShotgun) // Check if holding Shotgun 
            {
                handGrabber.HeldGrabbable.DropItem(handGrabber); // drop the Shotgun
                EquipGrabbableShotgun.transform.position = ShotgunCubeOrigin.transform.position; //return to origin position
                EquipGrabbableShotgun.transform.rotation = ShotgunCubeOrigin.transform.rotation; //return to origin rotation

                EquipGrabbableShotgun.GetComponent<Rigidbody>().isKinematic = true; // make kinematic so it doesn't fall to the ground
                Shotgun.SetActive(false); // disable the pistol so it disappears
            }
            Rifle.SetActive(true); //enable the rifle so it appears
            handGrabber.GrabGrabbable(EquipGrabbableRifle); // equip the rifle

            EquipGrabbableRifle.GetComponent<Rigidbody>().isKinematic = false; // set kinematic to false

            EquipGrabbableRifle.transform.SetParent(null); // set its parent to null so it doesn't disappear with the weapon wheel
        }
        //if nothing is being held, equip the rifle
        else
        {
            Rifle.SetActive(true); //enable rifle so it appears
            handGrabber.GrabGrabbable(EquipGrabbableRifle); // equip the rifle

            EquipGrabbableRifle.GetComponent<Rigidbody>().isKinematic = false; //  set kinematic to false

            EquipGrabbableRifle.transform.SetParent(null); //  set its parent to null so it doesn't disappear
        }

    }

    public void PistolSelect()
    {
        // check if pistol is already being held, if so do nothing
        if (handGrabber.HeldGrabbable == EquipGrabbablePistol)
        {
            return;
        }
        //check if the item being held is the rifle or shotgun, if so drop the item, return it to its orgin and equip the pistol
        if (handGrabber.HeldGrabbable != null)
        {
            if (handGrabber.HeldGrabbable == EquipGrabbableRifle) // Check if holding Rifle
            {
                handGrabber.HeldGrabbable.DropItem(handGrabber);
                EquipGrabbableRifle.transform.position = RifleCubeOrigin.transform.position;
                EquipGrabbableRifle.transform.rotation = RifleCubeOrigin.transform.rotation;
                EquipGrabbableRifle.GetComponent<Rigidbody>().isKinematic = true;
                Rifle.SetActive(false);

            }
            if (handGrabber.HeldGrabbable == EquipGrabbableShotgun) // Check if holding Shotgun 
            {
                handGrabber.HeldGrabbable.DropItem(handGrabber); // drop the Shotgun
                EquipGrabbableShotgun.transform.position = ShotgunCubeOrigin.transform.position; //return to origin position
                EquipGrabbableShotgun.transform.rotation = ShotgunCubeOrigin.transform.rotation; //return to origin rotation

                EquipGrabbableShotgun.GetComponent<Rigidbody>().isKinematic = true; // make kinematic so it doesn't fall to the ground
                Shotgun.SetActive(false); // disable the pistol so it disappears
            }

            Pistol.SetActive(true);
            handGrabber.GrabGrabbable(EquipGrabbablePistol);

            EquipGrabbablePistol.GetComponent<Rigidbody>().isKinematic = false;

            EquipGrabbablePistol.transform.SetParent(null);
        }
        //if nothing is being held, equip the pistol
        else
        {
            Pistol.SetActive(true);
            handGrabber.GrabGrabbable(EquipGrabbablePistol);

            EquipGrabbablePistol.GetComponent<Rigidbody>().isKinematic = false;

            EquipGrabbablePistol.transform.SetParent(null);
        }

    }

    public void EmptyHandSelect()
    {
        // if hand is already empty do nothing
        if (handGrabber.HeldGrabbable == null)
        {
            return;
        }

        if (handGrabber.HeldGrabbable != null)
        {
            //if held weapon is the rifle, drop the rifle and return it to its origin
            if (handGrabber.HeldGrabbable == EquipGrabbableRifle)
            {
                handGrabber.HeldGrabbable.DropItem(handGrabber);
                EquipGrabbableRifle.transform.position = RifleCubeOrigin.transform.position;
                EquipGrabbableRifle.transform.rotation = RifleCubeOrigin.transform.rotation;

                EquipGrabbableRifle.GetComponent<Rigidbody>().isKinematic = true;
                Rifle.SetActive(false);

            }
            //if held weapon is the pistol, drop the pistol and return it to its origin
            if (handGrabber.HeldGrabbable == EquipGrabbablePistol)
            {
                handGrabber.HeldGrabbable.DropItem(handGrabber);
                EquipGrabbablePistol.transform.position = PistolCubeOrigin.transform.position;
                EquipGrabbablePistol.transform.rotation = PistolCubeOrigin.transform.rotation;

                EquipGrabbablePistol.GetComponent<Rigidbody>().isKinematic = true;
                Pistol.SetActive(false);
            }
            //if held weapon is the shotgun, drop the shotgun and return it to its origin
            if (handGrabber.HeldGrabbable == EquipGrabbableShotgun)
            {
                handGrabber.HeldGrabbable.DropItem(handGrabber);
                EquipGrabbableShotgun.transform.position = ShotgunCubeOrigin.transform.position;
                EquipGrabbableShotgun.transform.rotation = ShotgunCubeOrigin.transform.rotation;

                EquipGrabbableShotgun.GetComponent<Rigidbody>().isKinematic = true;
                Shotgun.SetActive(false);
            }


        }
    }
}
