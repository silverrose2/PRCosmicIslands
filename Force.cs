
using UnityEngine;// sepearate this bility see how it functions can alway remove and combie but seems fine
using Opsive.UltimateCharacterController.Character.Abilities;//new
public class Force : Ability// not sure this even need to be attached to players works fine either way need to watch video again may have missed
   

{//My player had too many large colliders triggering animations so created empty object to put in tooltip so only central character triggers force
    [Tooltip("Femalefighter2")]// Opsive API ref/ Opsive  ref[Tooltip("Femalefighter2")]// Becomes private DetectObjectAbilityBase unity wont show pubic load load error but is fine
    [SerializeField] protected GameObject m_Character;// Opsive API ref
    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Force")// This tag could just be 'Enemy' GameObj placed centre of enemy so anim trigerer is played and force is applied after

        {
            AddForce(m_Transform.forward * (-400 * 25) + m_Transform.up * 3000);// realised there is no reverse transfrom command its simply a minus
          
        }

        if (other.tag == "Bossforce")// new 2.5.23 This tag could just be 'Enemy' GameObj placed centre of enemy so anim trigerer is played and force is applied after

        {
            AddForce(m_Transform.forward * (-800 * 50) + m_Transform.up * 3000);// realised there is no reverse transfrom command its simply a minus
        }

        if (other.tag == "Padforce")// new 2.5.23 This tag could just be 'Enemy' GameObj placed centre of enemy so anim trigerer is played and force is applied after

        {

            AddForce(m_Transform.up * 15000);//Just up force for jump pad
        }
    }
    //500 prev
}



// AddForce(m_Transform.forward * (-8000 * 25) + m_Transform.up * 600); Fast backwards - is reverse there is no forward code i can see. extreme
// AddForce(m_Transform.forward * (-800 * 25) + m_Transform.up * 600); Basic
// AddForce(m_Transform.forward * (-100 * 25) + m_Transform.up * 2000); Subtle push back height emphasis
//My method of a Players agame obj enemy attack animation detect collider was 60 x 60 reduced to work with force 09.04.23