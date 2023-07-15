using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemydamagetogivetoplayerPR : MonoBehaviour// This scrip attaches to a bullet. ref what bullet is hitting for damage
{// Dont forget tag Enemy in Unity as Enemy *****************************
    public int damageToGive;// access to enemy health pay attention to the upper and lower case formats
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    //void OnCollisionEnter2D (Collider2D other)
    void OnTriggerEnter(Collider other)
    // can use OnCollisionEnter too 
    {
        //(other.gameObject.name == "Dan")
        if (other.tag == "Player")
        //if  (other.gameObject.name == "DemonBoss")
        //(other.gameObject.name == "DemonBoss")  //for object /title instead of tag
        {//if this is player bullet then below should ref the enemy script.
            other.gameObject.GetComponent<PlayerhealthPR>().HurtPlayer(damageToGive);//ThePlayer/ enemy script
            //public AudioSource Enemymoan; //this creates a source slot for audio
            //Destroy(gameObject);
        }
    }
}