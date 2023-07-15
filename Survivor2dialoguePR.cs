using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;// by p.rose// Note this is a shared script for all survivors if you want to make a change will need to create a new version of this script i.e Kara or Max survivor 1/2 etc

public class Survivor2dialoguePR : MonoBehaviour
{

    public TextMeshProUGUI Text1;
    public TextMeshProUGUI Text2;
    // public TextMeshProUGUI takecover; NOT REL
    public GameObject Survivor2Camera;
    public GameObject Maincamera;
    public GameObject Helirescue2;
    public GameObject Survivor2;
    public GameObject Levelselectobj;
    Animator anim;

    // public GameObject Survivor1;// ignore this for now this will be set active with defeat of enemy boss

    // Start is called before the first frame update
    void Start()
    {
        //Survivor1.SetActive(false);// initially all these items are off
     //   Survivor2.SetActive(false);
        Survivor2Camera.SetActive(false);
        Helirescue2.SetActive(false);
        Text1.enabled = false;
        Text2.enabled = false;
        // takecover.enabled 
        anim = GetComponent<Animator>();
        //anim.SetInteger("Condition", 88);// run
        //     Levelselectobj.SetActive(false);

    }

    public void OnTriggerEnter(Collider other)// New to stop NPC on contact with player to avoid push/ tree
    {
        if (other.tag == "Player")// on trigger these activate
        {
            StartCoroutine(delay(v: 30));// set delay function in motion
                                         // Survivor1.SetActive(true);
            Survivor2Camera.SetActive(true);
            Maincamera.SetActive(false);
            Text1.enabled = true;

        }
        IEnumerator delay(int v) // need to switch off respawn
        {
            yield return new WaitForSeconds(5.0f);// seconds delay 6 about right
            Survivor2Camera.SetActive(true);
            Maincamera.SetActive(false);
            Text1.enabled = false;
            Text2.enabled = true;
            Helirescue2.SetActive(true);
            yield return new WaitForSeconds(6.0f);

            Survivor2Camera.SetActive(false);// resumes
            Maincamera.SetActive(true);
            Text1.enabled = false;
            Text2.enabled = false;
            Helirescue2.SetActive(true);
            Survivor2.GetComponent<BoxCollider>().enabled = false;// disables collider
            Destroy(GetComponent<Freezesurvivor1>());// now that we are done with freeze lets destroy it so wont repeat.
            anim.SetInteger("Condition", 88);// run
                                             // takecover.enabled = true;
                                             // Levelselectobj.SetActive(true);
            yield return new WaitForSeconds(8.0f);//9
            Survivor2.SetActive(false);

            if (other.tag == "Player")// on trigger these activate
            {
                StartCoroutine(delay(v: 30));// set delay function in motion
                                             // Survivor1.SetActive(true);
                Survivor2Camera.SetActive(false);
                Maincamera.SetActive(true);
                Text1.enabled = false;
                Text2.enabled = false;// this section checks we dont repeat if on contact with player 2nd time this works really well 28.05 PR


            }
        }
    }
}







