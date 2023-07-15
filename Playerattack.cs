using System.Collections;
using System.Collections.Generic;
using UnityEngine;// PR Attack script yet to get working
//I'm using integers set up on branch in state machine// this script is attached to enemy empty game obj withbox collider 
// a collider box collider must be set on enemy and player with enemy as trigger selected PR
public class Playerattack : MonoBehaviour// I have set 1 as the anim integer. 2 is default for no action in statemachine
{// NOTE create empty game obj attach to player

    Animator anim;
    public AudioSource Roar;// drag in roar

    void Start()
    {
        Roar= GetComponent<AudioSource>();// new 26.4.23
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)// action should trigger any time as has if statement
    {
        if (other.gameObject.CompareTag("Playerdetect"))// player is detected far off ani plays
        {
            anim.SetInteger("Condition", 1);// Condition the name generated for integer in unity (1 value ref for anim)PR
            Roar.Play();
        }// 2 is attack animation

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Playerdetect"))// PR -or set to "Player" with no obj attach1 is walking animation switches off
        {
            anim.SetInteger("Condition", 0);// Condition the name generated for integer in unity (1 value ref for anim)PR
        }// this exit and set to default state i.e carry on walk or idle is important is turns off animation when enemy out of player range PR
    }
}


