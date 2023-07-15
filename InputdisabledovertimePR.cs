using System.Collections;
using UnityEngine;
using Opsive.Shared.Events;// added noted in new API 


public class InputdisabledovertimePR : MonoBehaviour// tip always call functions in the right order animator funtion b4 condition 1
                                                   // note spell error on inpu


{

    // For delay on toggle to allow animation to flow with no glitch PR
    [Tooltip("A reference to the Ultimate Character Controller character.")]
    [SerializeField] public GameObject Femalefighter2;// changed this from private to public to make easier and versatilve

    /// <summary>
    /// Disable the input.
    /// </summary>
    private void Start()
    {
        StartCoroutine(delay(v: 30));
        EventHandler.ExecuteEvent(Femalefighter2, "OnEnableGameplayInput", false);// sets movement true
    }


    IEnumerator delay(int v)

    {
        yield return new WaitForSeconds(65f);// allow fraction of time so Y button can be pressed 0.4 wait
        EventHandler.ExecuteEvent(Femalefighter2, "OnEnableGameplayInput", true);// freeze
    }
}


