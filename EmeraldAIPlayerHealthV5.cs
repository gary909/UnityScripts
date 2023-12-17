using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using EmeraldAI.CharacterController;
//using UnityEngine.UI; // Remove this line
using TMPro; // Add this line

namespace EmeraldAI.Example
{
    /// <summary>
    /// An example health script that the EmeraldAIPlayerDamage script calls.
    /// Various events can be created and used to cause damage to a 3rd party character controllers via the inspector.
    /// You can also edit the EmeraldAIPlayerDamage script directly and add custom functions.
    /// 
    /// **This modified version is sending the health & amour amount as text to the canvas with Text Mesh Pro**
    ///  **We also check for armour before removing health.  Values have been clamped so you don't get negative nums**
    ///  ***V5 Health text now goes red when below 25***
    ///
    /// </summary>
    public class EmeraldAIPlayerHealth : MonoBehaviour
    {
        public int CurrentHealth = 70;[Space] // Health
        public int CurrentArmour = 0;[Space] // Armour

        public UnityEvent DamageEvent;
        public UnityEvent DeathEvent;

        // Text for Canvas
        public TMP_Text currentHealth_UI_Text;
        public TMP_Text currentArmour_UI_Text;

        [HideInInspector]
        public int StartingHealth;

        [HideInInspector]
        public int StartingArmour;  // Armour

        private void Start()
        {
            StartingHealth = CurrentHealth; // Health Starting Amount
            StartingArmour = CurrentArmour; // Armour Starting Amount 
            UpdateHealth_UI_Text(); // Health UI Text
            UpdateArmour_UI_Text(); // Armourh UI Text
        }

        // Make CurrentHealth int accessible to other scripts (eg HealthPickup.cs)              // Not needed?  Remove??
        //public int GetCurrentHealth()
        //{
            //return CurrentHealth;
        //}
        
        public void DamagePlayer(int DamageAmount)
        {
            int initDamage = CurrentArmour - DamageAmount; // init Check if damage taken results in Armour negative amount

            if (initDamage <= 0) // If Armour is zero or less do this...
            {
                CurrentHealth -= DamageAmount; // remove health points
                CurrentHealth = Mathf.Clamp(CurrentHealth, 0, 200); // clamp values so health isn't below 0 or over 200
            }

            // Else if Armour available to cover damage do this;
            CurrentArmour -= DamageAmount; // remove armour points
            CurrentArmour = Mathf.Clamp(CurrentArmour, 0, 200); // clamp values so armour isn't below 0 or over 200

            //Debug.Log(CurrentHealth);
            UpdateHealth_UI_Text(); // Text for Canvas
            UpdateArmour_UI_Text(); // Text for Canvas

            DamageEvent.Invoke();

            if (CurrentHealth <= 0)
            {
                PlayerDeath();
            }
        }

        void ApplyHeal(int heal)
        {
            if(CurrentHealth > 100)
            {
                // Do nothing
            } 
            else if (CurrentHealth + heal > 100)
            {
                CurrentHealth = 100;
                UpdateHealth_UI_Text(); // upDate UI Text 
            } 
            else
            {
            //Stores the current health and subtracts the dame value
            CurrentHealth += heal; // add health points from healthPickup
            UpdateHealth_UI_Text(); // upDate UI Text 
            }
        }

        void ApplyHealMega(int heal) // For applying 200 HP OR 1hp for small pickup
        {
            if (CurrentHealth > 200)
            {
                // Do nothing
            }
            else if (CurrentHealth + heal > 200)
            {
                CurrentHealth = 200;
                UpdateHealth_UI_Text(); // upDate UI Text 
            }
            else
            {
                //Stores the current health and subtracts the dame value
                CurrentHealth += heal; // add health points from healthPickup
                UpdateHealth_UI_Text(); // upDate UI Text 
            }
        }

        void ApplyArmour(int ArmrAmnt) // Add 100 Armour HP from ArmourPickup.cs
        {
            if (CurrentArmour > 100)
            {
                // Do nothing
            }
            else if (CurrentArmour + ArmrAmnt > 100)
            {
                CurrentArmour = 100;
                UpdateArmour_UI_Text(); // upDate UI Text 
            }
            else
            {
                //Stores the current health and subtracts the dame value
                CurrentArmour += ArmrAmnt; // add health points from healthPickup
                UpdateArmour_UI_Text(); // upDate UI Text 
            }
        }

        void ApplyArmourMega(int ArmrAmnt) // For applying 200 HP OR 1hp for small pickup
        {
            if (CurrentArmour > 200)
            {
                // Do nothing
            }
            else if (CurrentArmour + ArmrAmnt > 200)
            {
                CurrentArmour = 200;
                UpdateArmour_UI_Text(); // upDate UI Text 
            }
            else
            {
                //Stores the current health and subtracts the dame value
                CurrentArmour += ArmrAmnt; // add health points from healthPickup
                UpdateArmour_UI_Text(); // upDate UI Text 
            }
        }

        // Code for Canvas UI
        public void UpdateHealth_UI_Text()
        {
            currentHealth_UI_Text.text = CurrentHealth.ToString(); // working
            if (CurrentHealth <=25)
            {
                currentHealth_UI_Text.color = new Color(1f, 0.01f, 0.00f); // if less than 25 health text goes Red
            } else
            {
                currentHealth_UI_Text.color = new Color(0.93f, 0.64f, 0.19f); // Normal Text Orange
            }
        }

        // Code for Canvas UI
        public void UpdateArmour_UI_Text()
        {
            currentArmour_UI_Text.text = CurrentArmour.ToString(); // working
        }

        public void PlayerDeath()
        {
            DeathEvent.Invoke();
        }
    }
}
