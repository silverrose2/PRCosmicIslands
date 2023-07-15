using UnityEngine;// This script doea not need to be attached to any object as long as its typed and saved.
using Opsive.UltimateCharacterController.Character.Abilities;//new
using Opsive.UltimateCharacterController.Character;
public class Knockback : DetectObjectAbilityBase// 

//****Foucus on position of colliders.Any animation trigger colliders on character may need to be reworked to function with force work with force as to not get in the way or conflict.Experiment with tags

{
    [Tooltip("Your character title goes here")]// Becomes private DetectObjectAbilityBase 
    [SerializeField] protected GameObject m_Character;// Opsive API ref

    // public override void OnTriggerEnter(Collider other)
    //{
    //     if (other.tag == "Enemy")// could use a seperate game objetc on player to define centre of enemy here 

    //  {// change values 500 and 3000 to suit
    //  AddForce(m_Transform.forward * (-500 * 25) + m_Transform.up * 3000);// there is no reverse command its simply a minus
    //    }

    //}

    public override void OnTriggerExit(Collider other) // works withobj identifier script
    {
        if (other.gameObject == m_DetectedObject)

        {
            StopAbility();

        }
        base.OnTriggerExit(other);
    }
}
//t collider was 60 x 60 reduced to work with force 09.04.23