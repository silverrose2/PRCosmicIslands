using UnityEngine;// This incorprate an auto equip to upper left and right trigger works but caused freeze equip after time
using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Character.Abilities.Items;
using System.Collections;// mus be included 

public class Equipcontrol4 : MonoBehaviour
{
    [Tooltip("A reference to the Ultimate Character Controller character.")]
    [SerializeField] protected GameObject m_Character;

    /// <summary>
    /// Equips the item.
    /// </summary>
    private void Update()
    {// 5ht for MG
        if (Input.GetButtonDown("Grenade"))// equip tenth item prev
        {//Working well set time delay on start to same to keep in synch to prevent anim issues 0.5 
            var characterLocomotion = m_Character.GetComponent<UltimateCharacterLocomotion>();
            if (characterLocomotion != null)
            {
                // Equip a specific index within the ItemSetManager with the EquipUnequip ability.
                var equipUnequip = characterLocomotion.GetAbility<EquipUnequip>();
                if (equipUnequip != null)
                {
                    // Equip the ItemSet at index 2 within the ItemSetManager.
                    equipUnequip.StartEquipUnequip(2);
                }

            }
        }
    }
}