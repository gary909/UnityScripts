using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class PistolAquired : MonoBehaviour
{
    private Grabbable pistolGrabable; // pisol to be destroyed
    public Grabber handGrabber; //  pistol to be destroyed
    public GameObject playerController;
    public GameObject Pistol; //weaponwheelPistol
    public Grabbable EquipGrabbablePistol;


    void Start()
    {
        pistolGrabable = GetComponent<Grabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pistolGrabable.BeingHeld == true)
        {
            switchPistol();
        }
    }

    public void switchPistol()
    {
        playerController.GetComponent<EnableWeaponWhell>().enabled = true;

        Pistol.SetActive(true);

        EquipGrabbablePistol.GetComponent<Rigidbody>().isKinematic = false;

        EquipGrabbablePistol.transform.SetParent(null);

        handGrabber.HeldGrabbable.DropItem(handGrabber);

        handGrabber.GrabGrabbable(EquipGrabbablePistol);

        Destroy(gameObject);
    }
}
