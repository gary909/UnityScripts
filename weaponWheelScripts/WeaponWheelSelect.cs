using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

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




    public void RifleSelect()
    {

        // check if rifle is already being held, if so do nothing
        if (handGrabber.HeldGrabbable == EquipGrabbableRifle)
        {
            return;
        }

        //check if the item being held is the pistol, if so drop the pistol, return it to its orgin and equip the rifle
        if (handGrabber.HeldGrabbable != null)
        {
            if (handGrabber.HeldGrabbable == EquipGrabbablePistol)
            {
                handGrabber.HeldGrabbable.DropItem(handGrabber); // drop the rifle
                EquipGrabbablePistol.transform.position = PistolCubeOrigin.transform.position; //return to origin position
                EquipGrabbablePistol.transform.rotation = PistolCubeOrigin.transform.rotation; //rerurn to origin rotation

                EquipGrabbablePistol.GetComponent<Rigidbody>().isKinematic = true; // make kinematic so it doesn't fall to the ground
                Pistol.SetActive(false); // disable the pistol so it disappears
            }
            Rifle.SetActive(true); //enable the rifle so it appears
            handGrabber.GrabGrabbable(EquipGrabbableRifle); // equip the rifle

            EquipGrabbableRifle.GetComponent<Rigidbody>().isKinematic = false; // set kinematic to false

            EquipGrabbableRifle.transform.SetParent(null); // set its parent to null so it doesn't disappear with the weapon wheel
        }
        //if nothing is being held, equip the rifle
        else
        {
            if (handGrabber.HeldGrabbable != null) // added
            {
                handGrabber.HeldGrabbable.DropItem(handGrabber);
            }
            else
            {
                Rifle.SetActive(true); //enable rifle so it appears
                handGrabber.GrabGrabbable(EquipGrabbableRifle); // equip the rifle

                EquipGrabbableRifle.GetComponent<Rigidbody>().isKinematic = false; //  set kinematic to false

                EquipGrabbableRifle.transform.SetParent(null); //  set its parent to null so it doesn't disappear
            }
        }

    }

    public void PistolSelect()
    {
        // check if pistol is already being held, if so do nothing
        if (handGrabber.HeldGrabbable == EquipGrabbablePistol)
        {
            return;
        }
        //check if the item being held is the rifle, if so drop the item, return it to its orgin and equip the pistol
        if (handGrabber.HeldGrabbable != null)
        {
            if (handGrabber.HeldGrabbable == EquipGrabbableRifle)
            {
                handGrabber.HeldGrabbable.DropItem(handGrabber);
                EquipGrabbableRifle.transform.position = RifleCubeOrigin.transform.position;
                EquipGrabbableRifle.transform.rotation = RifleCubeOrigin.transform.rotation;
                EquipGrabbableRifle.GetComponent<Rigidbody>().isKinematic = true;
                Rifle.SetActive(false);

            }

            Pistol.SetActive(true);
            handGrabber.GrabGrabbable(EquipGrabbablePistol);

            EquipGrabbablePistol.GetComponent<Rigidbody>().isKinematic = false;

            EquipGrabbablePistol.transform.SetParent(null);
        }
        //if nothing is being held, equip the pistol
        else
        {
            if (handGrabber.HeldGrabbable != null) // added
            {
                handGrabber.HeldGrabbable.DropItem(handGrabber);
            }
            else
            {
                Pistol.SetActive(true);
                handGrabber.GrabGrabbable(EquipGrabbablePistol);

                EquipGrabbablePistol.GetComponent<Rigidbody>().isKinematic = false;

                EquipGrabbablePistol.transform.SetParent(null);
            }
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

            else // added
            {
                if (handGrabber.HeldGrabbable != null)
                {
                    handGrabber.HeldGrabbable.DropItem(handGrabber);
                }
            }


        }
    }
}
