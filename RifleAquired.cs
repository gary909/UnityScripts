using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class RifleAquired : MonoBehaviour
{
    private Grabbable rifleGrabable; // rifle to be destroyed
    public Grabber handGrabber;
    public GameObject playerController;
    public GameObject Rifle; //weaponwheelRifle
    public Grabbable EquipGrabbableRifle;//weaponwheelRifle
    public GameObject rifleCube;


    void Start()
    {
        rifleGrabable = GetComponent<Grabbable>();
    }

    void Update()
    {
        if (rifleGrabable.BeingHeld == true)
        {
            switchRifle();
        }
    }

    public void switchRifle()
    {

        rifleCube.SetActive(true);

        Rifle.SetActive(true);

        EquipGrabbableRifle.GetComponent<Rigidbody>().isKinematic = false;

        EquipGrabbableRifle.transform.SetParent(null);

        handGrabber.HeldGrabbable.DropItem(handGrabber);

        handGrabber.GrabGrabbable(EquipGrabbableRifle);

        Destroy(gameObject);
    }
}
