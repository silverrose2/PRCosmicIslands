using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opsive.UltimateCharacterController.Character;

public class GravityOriginalPR : MonoBehaviour
{

    void OnTriggerEnter(Collider other)//
    {
        if (other.tag == "Gravitytest")// Select a gameobject i.e cube and tag it with this adding a trigger collider too
        {
            gameObject.GetComponent<UltimateCharacterLocomotion>().GravityAmount = (-2f);
        }
    }
}

//GravityAmount=(0.2f); // usual
//GravityAmount=(1f); // extreme
//GravityAmount=(-10f);// flight