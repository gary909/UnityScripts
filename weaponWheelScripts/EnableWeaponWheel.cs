using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWeaponWheel : MonoBehaviour
{
    public GameObject weaponWheel; // the weaponWheel parent empty
    public GameObject targetposition;  // ModelsRight or ModelsLeft

    void Update()
    {

        //if you click your right thumbstick down it enables the weapon wheel / note remove model select on click 
        if (Input.GetButton("Oculus_CrossPlatform_SecondaryThumbstick"))
        {
            if (weaponWheel.activeSelf == false)
            {
                weaponWheel.SetActive(true);
                weaponWheel.transform.position = targetposition.transform.position;
                // weaponWheel.transform.rotation = targetposition.transform.rotation;
            }
        }
        //if if you let off the stick it disables the weapon wheel
        else
        {
            weaponWheel.SetActive(false);
        }

    }
}
