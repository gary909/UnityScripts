using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro; // Add this line for TextMeshPro

// Code modified for use with Text Mesh Pro

namespace BNG {
    public class AmmoDisplay : MonoBehaviour {

        public RaycastWeapon Weapon;
        public TextMeshProUGUI AmmoLabel; // Change the type to TextMeshProUGUI

        void OnGUI() {
            string loadedShot = Weapon.BulletInChamber ? "1" : "0";
            AmmoLabel.text = loadedShot + " / " + Weapon.GetBulletCount();
        }
    }
}

