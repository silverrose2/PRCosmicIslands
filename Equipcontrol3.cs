using UnityEngine;
using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Character.Abilities.Items;
using System.Collections;// mus be included 
public class Equipcontrol3 : MonoBehaviour// wait 20 secs then this will happen after mg equip
{
    //bool Equipped
    [Tooltip("A reference to the Ultimate Character Controller character.")]
    [SerializeField] protected GameObject m_Character;

    /// <summary>
    /// Equips the item.
    /// </summary>
    /// 
    public void OnTriggerEnter(Collider other)// New to stop NPC on contact with player to avoid push
    {// was an issue here i fived by adding !mgequipped dont want firing here
        if (other.tag == "axepickup") // onlly works when not equipped to solve issue ..
        {
            var characterLocomotion = m_Character.GetComponent<UltimateCharacterLocomotion>();
            if (characterLocomotion != null)
            {
                // Equip a specific index within the ItemSetManager with the EquipUnequip ability.
                var equipUnequip = characterLocomotion.GetAbility<EquipUnequip>();
                if (equipUnequip != null)
                {
                    equipUnequip.StartEquipUnequip(2);
                    //   StartCoroutine(delay(v: 30));
                }
                //   IEnumerator delay(int v)

            }
        }
    }
}