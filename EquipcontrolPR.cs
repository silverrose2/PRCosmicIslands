using UnityEngine;
using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Character.Abilities.Items;
using System.Collections;// mus be included 
public class EquipcontrolPR : MonoBehaviour// wait 20 secs then this will happen after mg equip
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
        if (other.tag == "mgpickup") // onlly works when not equipped to solve issue ..
        {
            var characterLocomotion = m_Character.GetComponent<UltimateCharacterLocomotion>();
            if (characterLocomotion != null)
            {
                // Equip a specific index within the ItemSetManager with the EquipUnequip ability.
                var equipUnequip = characterLocomotion.GetAbility<EquipUnequip>();
                if (equipUnequip != null)
                {
                    equipUnequip.StartEquipUnequip(1);
                    StartCoroutine(delay3(v: 30));
                }
                IEnumerator delay3(int v)

                {
                    yield return new WaitForSeconds(0.5f);
                    // Equip the ItemSet at index 2 within the ItemSetManager.
                    equipUnequip.StartEquipUnequip(1);
                    yield return new WaitForSeconds(19.5f);//19.4
                    equipUnequip.StartEquipUnequip(1);//set to equip works best to avoid unequip and fire 
                }

            }
        }
    }
}
