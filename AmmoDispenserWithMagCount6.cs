using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this line for TextMeshPro

namespace BNG {

    /// <summary>
    /// This is an example of how to spawn ammo depending on the weapon that is equipped in the opposite hand
    /// ***TMP Text: Modified Code also sent TMP text to the canvas counting Pistol Magazine amount***
    /// pistol ammo text colour now goes red when low 
    /// **-Update We now display the total amount of Bullets owned by palyer, rather than magazine amount***
    /// </summary>
    public class AmmoDispenser : MonoBehaviour {

        /// <summary>
        /// Used to determine if holding a weapon
        /// </summary>
        public Grabber LeftGrabber;

        /// <summary>
        /// Used to determine if holding a weapon
        /// </summary>
        public Grabber RightGrabber;

        /// <summary>
        /// Disable this if weapon not equipped
        /// </summary>
        public GameObject AmmoDispenserObject;

        /// <summary>
        /// Instantiate this if pistol equipped
        /// </summary>
        public GameObject PistolClip;

        /// <summary>
        /// Instantiate this if shotgun equipped
        /// </summary>
        public GameObject ShotgunShell;

        /// <summary>
        /// Instantiate this if shotgun equipped
        /// </summary>
        public GameObject RifleClip;

        /// <summary>
        /// Amount of Pistol Clips currently available
        /// </summary>
        public int CurrentPistolClips = 5;
        // Display amount of pistol clips on Canvas
        public TextMeshProUGUI UiPistolMagCountTMP; // ***TMP Text: Reference to TextMeshPro object***
        public int TotalPistolBullets // This function lets us display the total number of Pistol bullets available to the player
        {
            get
            {
                return CurrentPistolClips * 18; // 18 is the number of Pistol bullets in a magazine, mulitplied by no of magazines
            }
        }

        public int CurrentRifleClips = 5;
        public TextMeshProUGUI UiRifleMagCountTMP; // ***TMP Text: Reference to TextMeshPro object***
        public int TotalRifleBullets // This function lets us display the total number of Rifle bullets available to the player
        {
            get
            {
                return CurrentRifleClips * 30; // 30 is the number of Rifle bullets in a magazine, mulitplied by no of magazines
            }
        }

        public int CurrentShotgunShells = 15;
        public TextMeshProUGUI UiShotgunMagCountTMP; // ***TMP Text: Reference to TextMeshPro object***

        // Update is called once per frame
        void Update() {
            bool weaponEquipped = false;

            if (grabberHasWeapon(LeftGrabber) || grabberHasWeapon(RightGrabber)) {
                weaponEquipped = true;
            }

            // Only show if we have something equipped
            if(AmmoDispenserObject.activeSelf != weaponEquipped) {
                AmmoDispenserObject.SetActive(weaponEquipped);
            }
        }

        bool grabberHasWeapon(Grabber g) {

            if(g == null || g.HeldGrabbable == null) {
                return false;
            }

            // Holding shotgun, pistol, or rifle
            string grabName = g.HeldGrabbable.transform.name;
            if (grabName.Contains("Shotgun") || grabName.Contains("Pistol") || grabName.Contains("Rifle")) {
                //UiPistolMagCountTMP.text = CurrentPistolClips.ToString() + "0"; // ***TMP Text: Sets the starting amount of Pistol magazines on the canvas*** OLD
                UiPistolMagCountTMP.text = TotalPistolBullets.ToString(); // Displays Total number of Pistol bullets available to player - NEW
                UiShotgunMagCountTMP.text = CurrentShotgunShells.ToString(); // ***TMP Text: Sets the starting amount of Shotgun shells on the canvas***
                //UiRifleMagCountTMP.text = CurrentRifleClips.ToString() + "0"; // ***TMP Text: Sets the starting amount of Rifle magazines on the canvas*** OLD
                UiRifleMagCountTMP.text = TotalRifleBullets.ToString(); // Displays Total number of Pistol bullets available to player - NEW
                return true;
            }

            return false;
        }

        public GameObject GetAmmo() {

            bool leftGrabberValid = LeftGrabber != null && LeftGrabber.HeldGrabbable != null;
            bool rightGrabberValid = RightGrabber != null && RightGrabber.HeldGrabbable != null;

            // Shotgun
            if (leftGrabberValid && LeftGrabber.HeldGrabbable.transform.name.Contains("Shotgun") && CurrentShotgunShells > 0) {
                CurrentShotgunShells--;
                if (CurrentShotgunShells < 7)
                {
                    UiShotgunMagCountTMP.color = new Color(1f, 0.01f, 0.00f); // if less than 7 Shells text goes Red
                }
                else
                {
                    UiShotgunMagCountTMP.color = new Color(0.93f, 0.64f, 0.19f); // Normal Text Orange
                }
                return ShotgunShell;
            }
            else if (rightGrabberValid && RightGrabber.HeldGrabbable.transform.name.Contains("Shotgun") && CurrentShotgunShells > 0) {
                CurrentShotgunShells--;
                if (CurrentShotgunShells < 7)
                {
                    UiShotgunMagCountTMP.color = new Color(1f, 0.01f, 0.00f); // if less than 7 Shells text goes Red
                }
                else
                {
                    UiShotgunMagCountTMP.color = new Color(0.93f, 0.64f, 0.19f); // Normal Text Orange
                }
                return ShotgunShell;
            }

            // Rifle
            if (leftGrabberValid && LeftGrabber.HeldGrabbable.transform.name.Contains("Rifle") && CurrentRifleClips > 0) {
                CurrentRifleClips--;
                if (CurrentRifleClips < 2)
                {
                    UiRifleMagCountTMP.color = new Color(1f, 0.01f, 0.00f); // if less than 3 bullets text goes Red
                }
                else
                {
                    UiRifleMagCountTMP.color = new Color(0.93f, 0.64f, 0.19f); // Normal Text Orange
                }
                return RifleClip;
            }
            else if (rightGrabberValid && RightGrabber.HeldGrabbable.transform.name.Contains("Rifle") && CurrentRifleClips > 0) {
                CurrentRifleClips--;
                if (CurrentRifleClips < 2)
                {
                    UiRifleMagCountTMP.color = new Color(1f, 0.01f, 0.00f); // if less than 3 bullets text goes Red
                }
                else
                {
                    UiRifleMagCountTMP.color = new Color(0.93f, 0.64f, 0.19f); // Normal Text Orange
                }
                return RifleClip;
            }

            // Pistol
            if (leftGrabberValid && LeftGrabber.HeldGrabbable.transform.name.Contains("Pistol") && CurrentPistolClips > 0) {
                CurrentPistolClips--;
                //UiPistolMagCountTMP.text = CurrentPistolClips.ToString() + "0"; // ***TMP Text: Updates the number of Pistol magazines on the canvas***
                if (CurrentPistolClips < 2)
                {
                    UiPistolMagCountTMP.color = new Color(1f, 0.01f, 0.00f); // if less than 3 bullets text goes Red
                }
                else
                {
                    UiPistolMagCountTMP.color = new Color(0.93f, 0.64f, 0.19f); // Normal Text Orange
                }
                return PistolClip;
            }
            else if (rightGrabberValid && RightGrabber.HeldGrabbable.transform.name.Contains("Pistol") && CurrentPistolClips > 0) {
                CurrentPistolClips--;
                //UiPistolMagCountTMP.text = CurrentPistolClips.ToString() + "0";  // ***TMP Text: Updates the number of Pistol magazines on the canvas***
                if (CurrentPistolClips < 2)
                {
                    UiPistolMagCountTMP.color = new Color(1f, 0.01f, 0.00f); // if only 1 magazine left text goes Red
                }
                else
                {
                    UiPistolMagCountTMP.color = new Color(0.93f, 0.64f, 0.19f); // Normal Text Orange
                }
                return PistolClip;
            }

            // Default to nothing
            return null;
        }

        public void GrabAmmo(Grabber grabber) {

            GameObject ammoClip = GetAmmo();
            if(ammoClip != null) {
                GameObject ammo = Instantiate(ammoClip, grabber.transform.position, grabber.transform.rotation) as GameObject;
                Grabbable g = ammo.GetComponent<Grabbable>();

                // Disable rings for performance
                GrabbableRingHelper grh = ammo.GetComponentInChildren<GrabbableRingHelper>();
                if (grh) {
                    Destroy(grh);
                    RingHelper r = ammo.GetComponentInChildren<RingHelper>();
                    Destroy(r.gameObject);
                }

                // Offset to hand
                ammo.transform.parent = grabber.transform;
                ammo.transform.localPosition = -g.GrabPositionOffset;
                ammo.transform.parent = null;

                grabber.GrabGrabbable(g);
            }
        }

        public virtual void AddAmmo(string AmmoName) {
            if(AmmoName.Contains("Shotgun")) {
                CurrentShotgunShells++;
            }
            else if (AmmoName.Contains("Rifle")) {
                CurrentRifleClips--;
            }
            else if (AmmoName.Contains("Pistol")) {
                CurrentPistolClips++;
            }
        }
    }
}

