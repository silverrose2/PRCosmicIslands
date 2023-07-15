using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;// by p.rose// Note this is a shared script for all survivors if you want to make a change will need to create a new version of this script i.e Kara or Max survivor 1/2 etc

public class RuntoshipPR : MonoBehaviour
{
    public GameObject test;
    public GameObject Survivor1;
    // public GameObject Levelselectobj;
    Animator anim;
    public GameObject Shipcam1;
    public GameObject Shipcam2;


    // public GameObject Survivor1;// ignore this for now this will be set active with defeat of enemy boss
    void Start()
    {

        //Survivor1.SetActive(false);// initially all these items are off
        // Survivor1.SetActive(false);
        anim = GetComponent<Animator>();
        //Levelselectobj.SetActive(false);
       

        {
            StartCoroutine(delay(v: 30));// set delay function in motion
                                         // Survivor1.SetActive(true);
        }
        IEnumerator delay(int v) // need to switch off respawn
        {
            yield return new WaitForSeconds(20.3f);// seconds delay 6 about right was 20 cahnged to 20.3 0.3 allowance scene change
            Shipcam1.SetActive(false);
            Shipcam2.SetActive(true);
            // Survivor1.SetActive(true);
            //  Survivor1.GetComponent<BoxCollider>().enabled = false;// disables collider
            // Destroy(GetComponent<Freezesurvivor1>());// now that we are done with freeze lets destroy it so wont repeat.
            anim.SetInteger("Condition", 88);// run
           
            //Levelselectobj.SetActive(true);
            // yield return new WaitForSeconds(20.0f);//9
            //Survivor1.SetActive(false);
        }
    }
}







