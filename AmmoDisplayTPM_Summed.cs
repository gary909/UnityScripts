using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this line for TextMeshPro

// Code modified for use with Text Mesh Pro
// Second modified part of code combines the
// chambered bullet value and BulletCount into one total

namespace BNG {
    public class AmmoDisplayTMP : MonoBehaviour {

        public RaycastWeapon Weapon;
        public TextMeshProUGUI AmmoLabel; // Change the type to TextMeshProUGUI

        void OnGUI() {
            string loadedShot = Weapon.BulletInChamber ? "1" : "0";
            //AmmoLabel.text = loadedShot + " / " + Weapon.GetBulletCount();  // Value below return the old '0/9' value

            // Further code combines this into one total:
            int loadedShotValue;                                        // Declare int that the string value of loadedShot will be converted to:
            int.TryParse(loadedShot, out loadedShotValue);              // attempt to parse the value using the TryParse functionality of the integer type
            int bullTotal = loadedShotValue + Weapon.GetBulletCount();  // Sum the chamberedBullet value and clip bullet amount value:
            AmmoLabel.text = bullTotal.ToString();                      // value below returns combined total as string
        }
    }
}

