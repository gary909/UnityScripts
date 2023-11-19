using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this line for TextMeshPro

// Code modified for use with Text Mesh Pro
// Second modified part of code combines the chambered bullet value and BulletCount into one total
// Third Modification: Bullet text goes red when less than 4 bullets remaining

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

            // Change Bullet Clip text colour if ammo running low
            if (bullTotal < 4)
            {
                AmmoLabel.color = new Color(1f, 0.01f, 0.00f); // if less than 4 bullets text goes Red
            }
            else
            {
                AmmoLabel.color = new Color(0.93f, 0.64f, 0.19f); // Normal Text Orange
            }
        }
    }
}

