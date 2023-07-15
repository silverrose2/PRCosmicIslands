using UnityEngine;
using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Character.Abilities;

public class Speedchangepr : MonoBehaviour// this is where I originally had it wrong above :Ability class in error previously
{
    [Tooltip("The character that should start and stop the speedchange ability.")]
    [SerializeField] protected GameObject m_Character;
    // Basically this will set the player into run so a solutiontion to enable disable below would be the most easiest way.
    /// <summary>
    /// Starts and stops the Speedchange ability.
    /// </summary>
    /// Just need to implement on trigger over update
    ///
    public GameObject Speedzone;
    public GameObject Lplayersgreenshoes;
    public GameObject Lplayersredshoes;

    public GameObject Rplayersgreenshoes;
    public GameObject Rplayersredshoes;

    void OnTriggerEnter(Collider other)// Made changes below as new text seems to work different*************************
    {

        if (other.tag == "Speedzone") // 
        {

            var characterLocomotion = m_Character.GetComponent<UltimateCharacterLocomotion>();
            var speedchangeAbility = characterLocomotion.GetAbility<SpeedChange>(); // potentially could add duplicate SpeedChange2 with altered speeds would need method to switch here. / toggle method
                                                                                    // Tries to start the jump ability.
                                                                                    // such as if it doesn't have a high enough priority or if CanStartAbility returns false.
            characterLocomotion.TryStartAbility(speedchangeAbility);// or change toTryStopAbility

            {
                characterLocomotion.TryStartAbility(speedchangeAbility); //or change toTryStopAbility
                characterLocomotion.MotorAcceleration = new Vector3(90, 0, 90);

            }
        }
    }
        void OnTriggerExit(Collider other)// Made changes below as new text seems to work different*************************
        {

            if (other.tag == "Speedzone") // actually speed zone
            {
                var characterLocomotion = m_Character.GetComponent<UltimateCharacterLocomotion>();
                var speedchangeAbility = characterLocomotion.GetAbility<SpeedChange>(); // potentially could add duplicate SpeedChange2 with altered speeds would need method to switch here. / toggle method
                                                                                        // Tries to start the jump ability.
                                                                                        // such as if it doesn't have a high enough priority or if CanStartAbility returns false.
                characterLocomotion.TryStartAbility(speedchangeAbility);// or change toTryStopAbility

                {
                    characterLocomotion.TryStartAbility(speedchangeAbility); //or change toTryStopAbility
                    characterLocomotion.MotorAcceleration = new Vector3(20, 0, 20);
                    Speedzone.SetActive(false);
                    Lplayersgreenshoes.SetActive(true);
                    Rplayersgreenshoes.SetActive(true);
                    Lplayersredshoes.SetActive(false);
                    Lplayersredshoes.SetActive(false);

            }
            }
        }
    }

         