using UnityEngine;// This script doea not need to be attached to any object as long as its typed and saved.
using Opsive.UltimateCharacterController.Character.Abilities;//new
using Opsive.UltimateCharacterController.Character;
public class GravitytriggerPR : Ability//

{
    [Tooltip("Femalefighter2")]//
    [SerializeField] protected GameObject m_Character;

    public override void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gravitytest")// Select a gameobject i.e cube and tag it with this adding a trigger collider too
        {
            GetComponent<UltimateCharacterLocomotion>().GravityAmount = (1.2f); ;// refer to gravityoriginal too does the same but with no ability drop down
        }

        if (other.tag == "Gravityexit")// Select a gameobject i.e cube and tag it with this adding a trigger collider too
        {
            GetComponent<UltimateCharacterLocomotion>().GravityAmount = (0.2f);// refer to gravityoriginal too does the same but with no ability drop down
        }
    }
}

