using UnityEngine;// This script doea not need to be attached to any object as long as its typed and saved.
using Opsive.UltimateCharacterController.Character.Abilities;//new
using Opsive.UltimateCharacterController.Character;
public class JetpackPR : Ability// not sure this even need to be attached to players works fine either way need to watch video again may have missed
    // when applying this script go to player locomotion ability drop down look for + and add the ability Jetpack.
{//My player had too many large colliders triggering animations so created empty object to put in tooltip so only central character triggers force
    [Tooltip("Femalefighter2")]// Opsive API ref/ Opsive  ref[Tooltip("Femalefighter2")]// Becomes private DetectObjectAbilityBase unity wont show pubic load load error but is fine
    [SerializeField] protected GameObject m_Character;// Opsive API ref

    bool Jumpactive = false;

    public override void InactiveUpdate()// this method works tried other methods not sure why only inactiveupdate works here.
    {
        base.InactiveUpdate();

        if (Jumpactive)

            // if (other.tag == "Force")// This tag could just be 'Enemy' GameObj placed centre of enemy so anim trigerer is played and force is applied after
            if (Input.GetButton("Jump"))// could implment also if (Input.GetButtonUp("Jump")) to cancel forces (would need to update button method jump stop from auto to up in inspector)
            {

                GetComponent<UltimateCharacterLocomotion>().GravityAmount = (0.4f);
                AddForce(m_Transform.forward * (50 * 25) + m_Transform.up * 1000);// 
                Jumpactive = true;

            }
    }

    public override void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Jetpack")

        {
            Jumpactive = true;

        }
        if (Input.GetKey(KeyCode.U)) // Have a force zone here instead and trigger event to enable and disable pressing jump and U/I together enables disables
                                     // ideallyset up as on trigger with a object pick up i.e jetpack model add co routine so it times out too.
        {
            Jumpactive = true;

        }

        if (Input.GetKey(KeyCode.I)) // Have a force zone here instead and trigger event to enable and disable
        {
            Jumpactive = false;
        }
        if (!Jumpactive)
        {
            GetComponent<UltimateCharacterLocomotion>().GravityAmount = (0.2f);
        }
    }

         public override void OnTriggerExit(Collider other)
    {

        if (other.tag == "Jetpackcancel")// here i have multiple cube / mesh unchecked, box colliders above ground level to cancel jump
            //I added code Jetpackpickup which controls when & how long these colliders are active

        {
            Jumpactive = false;

        }
    }
}

  
