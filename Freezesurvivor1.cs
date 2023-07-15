using System.Collections;
using UnityEngine;
using Opsive.Shared.Events;// added noted in new API 
public class Freezesurvivor1: MonoBehaviour// PR This scipt only works if you have the game object dragged
                                           // I have use this script and adapeted basically freeze the player when equiping and enequping suits my style of game
                                           // found in documents // https://opsive.com/support/documentation/ultimate-character-controller/input/you can adapt
{
    // For delay on toggle to allow animation to flow with no glitch PR
    [Tooltip("A reference to the Ultimate Character Controller character.")]
    [SerializeField] public GameObject Femalefighter2;// changed this from private to public to make easier and versatilve

    /// <summary>
    /// Disable the input.
    /// </summary>
    private void Start()
    {
        EventHandler.ExecuteEvent(Femalefighter2, "OnEnableGameplayInput", true);// sets movement true
    }

    public void OnTriggerEnter(Collider other)// New to stop NPC on contact with player to avoid push
    {// was an issue here i fived by adding !mgequipped dont want firing here
        if (other.tag == "survivor1")
        {

            {
                StartCoroutine(delay(v: 30));
                EventHandler.ExecuteEvent(Femalefighter2, "OnEnableGameplayInput", true);// set false for immediate block or allow some time
                //in my case enough to equip
            }
            IEnumerator delay(int v)
            {//.4 to allow drift to full idle to avoid anim transition probs. works best from completed idle pose
                yield return new WaitForSeconds(0.5f);// allow fraction of time so Y button can be pressed 0.4 wait
                EventHandler.ExecuteEvent(Femalefighter2, "OnEnableGameplayInput", false);// freeze
                yield return new WaitForSeconds(8.0f);// higher the better less issues time to unfreeze 
                EventHandler.ExecuteEvent(Femalefighter2, "OnEnableGameplayInput", true);// unfreeze
                yield return new WaitForSeconds(2.0f);// higher the better less issues time to unfreeze 
                EventHandler.ExecuteEvent(Femalefighter2, "OnEnableGameplayInput", true);// unfreeze// recheck in case enemy freezes player on pass
                yield return new WaitForSeconds(2.0f);// higher the better less issues time to unfreeze 
                EventHandler.ExecuteEvent(Femalefighter2, "OnEnableGameplayInput", true);// unfreeze// recheck in case enemy freezes player on pass
            }


            // no loaded gun basically a duplicate with no script located in hierachy GunSpawn 1
        }// PR
    }
}

// if (Input.GetAxisRaw("Fire1") != 0) THE FIRE TRIGGER
//   if (Input.GetButtonDown("Equip Next Item"))// string set up as y button/ joystick button 3
// Alwys remember use stings in code like names set up equip next, action, reload and input settings are in manager
//- as joystick button 1,2,3 etc...PR