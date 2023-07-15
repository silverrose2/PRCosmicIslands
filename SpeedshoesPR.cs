using UnityEngine;//
using System.Collections;
using Opsive.UltimateCharacterController.Character.Abilities;//new
using Opsive.UltimateCharacterController.Character;
public class Jumpstop : MonoBehaviour


{
    [Tooltip("The character that should start and stop the jump ability.")]
    [SerializeField] protected GameObject m_Character;

    /// <summary>
    /// Starts and stops the jump ability.
    /// </summary>
    private void Start()
    {
        var characterLocomotion = m_Character.GetComponent<UltimateCharacterLocomotion>();
        var jumpAbility = characterLocomotion.GetAbility<Jump>();
        // Tries to start the jump ability. There are many cases where the ability may not start, 
        // such as if it doesn't have a high enough priority or if CanStartAbility returns false.
        characterLocomotion.TryStartAbility(jumpAbility);

        // Stop the jump ability if it is active.
        if (jumpAbility.IsActive)
        {
            characterLocomotion.TryStopAbility(jumpAbility);
        }
    }
}
