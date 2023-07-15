
using System.Collections;// tested fine 12.5.23
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//by P Rose
// Possibly the most demanding script I have created its works and covers equip events created with trial and error a bool
//// rifle switch will be eaiser is its auto switch not selectable as this is causing conflict glitch where----
// ---certain combinations trigger fire when not needed changing taking out rifle switch to auto************************************************10.5.23
public class MeshRenderMelee : MonoBehaviour// This is really pick up handler and images should really be called pick up handler
{
    public GameObject Machinegunpickup;
    public GameObject RifleGunspawn;
    public GameObject Machinegunspawn;
    public GameObject Rifle;
    public GameObject Rifleclip;
    public GameObject Machinegun;
    public MeshRenderer Axe;// all you need is MeshRender
    public MeshRenderer Sword;
    public Image Axeimage;
    public Image Swordimage;
    public Image Rifleimage;
    public Image Machinegunimage;
    public AudioSource axepickup;// 
    public AudioSource Riflepickup;// drag in
    public GameObject AxeHit;
    public GameObject SwordHit;
    public GameObject Axetext;// 09.5.23 new
    public GameObject Axetextinstructions;// 09.5.23 new
    public GameObject Outofammo;// 09.5.23 new
    bool MachinegunEquipped;
    bool RifleEquip;
    bool AxeEquipped;// 1st bool created 09/5/23 working correctly to enable sword axe switch under bool condition axeequipped
    // This script switches images and sword and axe. Set start how you want images on start of game.-
    // - i.e if auto equipped current set up. the rifle image is set true as rifle held first
    // This script is all about pick ups and how weapons respond initially loaded weapon script is handling of gunfire when needed

//Note Keep tab on sword anabled code added x 2 MG and Axe co routeines**************************** 14/5********** should prevent equip freeze 

    void Start()

    {
     
        Machinegunimage.enabled = false;
        Machinegun.SetActive(false);
        Machinegunspawn.SetActive(false);
        RifleGunspawn.SetActive(true);
        Axetext.SetActive(false);
        Axetextinstructions.SetActive(false);
        Axeimage.enabled = false;// new 25/4 on start this applys etc
        Swordimage.enabled = true;// new 25/4 changed from true to false 29/4 pr******************
        Outofammo.SetActive(false);
        // Rifle.SetActive(true); // controlled by group icon
        // Machinegun.SetActive(false);

    }
    void Update()
    {

        {   // melle swapping


            if (Input.GetButtonDown("Reload") && AxeEquipped)// Use string not in use like Equip Ninth Item jsb 2 is X Button prev"Equip Ninth Item")
            {
                Axeimage.enabled = true; // new 25/4
                Swordimage.enabled = false;// new
                Axe.enabled = true;// actual axe mesh
                Sword.enabled = false;// sword mesh // possilbe if duration ends with axe you have no collider
                AxeHit.SetActive(true);
                SwordHit.SetActive(false);
            }

            if (Input.GetButtonDown("Grenade") && AxeEquipped) // jsb 1 is B Button prev ("Equip Tenth Item")
            {
                Axeimage.enabled = false;//new 25/4
                Swordimage.enabled = true;//new
                Axe.enabled = false;
                Sword.enabled = true;
                AxeHit.SetActive(true);
                SwordHit.SetActive(false);
            }

            // deactivated switching of shooter weapons ans fire continued after switch
            //equip machine gun deatitaed as 
            if (Input.GetButtonDown("Action") && MachinegunEquipped)// Use string  jsb 4 is l trig enable this and 2 block for switch prev ("Equip Fifth Item")
            {
                Rifleimage.enabled = false;
                Machinegunimage.enabled = true; // new 25/4
                Machinegun.SetActive(true);
                Rifle.SetActive(false); // controlled by group icon
                Rifleclip.SetActive(false);
                Machinegunspawn.SetActive(true);
                RifleGunspawn.SetActive(false);
                
            }//checking this is enabled f until axe swapping also this is main collider comp * 

            //unequip machine gun
            if (Input.GetButtonDown("Lean") && MachinegunEquipped)// jsb 5   is B Button r prrev ("Equip Sixth Item")
            {

                Rifle.SetActive(true); // controlled by group icon
                Rifleclip.SetActive(true);
                Machinegun.SetActive(false);
                Machinegunspawn.SetActive(false);
                RifleGunspawn.SetActive(true);
                Rifleimage.enabled = true;
                Machinegunimage.enabled = false;                 
            }
        }
       
        // switching unequipped making sure nothing happen

        //  below will prevent fire when used to be able to switch unequip didnt work so will disable with the x 2
        //  if (Input.GetButtonDown("Equip Sixth Item") && !MachinegunEquipped)// jsb 9 is B Button r trig
        //   {
        //   Rifle.SetActive(true); // controlled by group icon
        //   Rifleclip.SetActive(true);
        //   Machinegun.SetActive(false);
        //   Machinegunspawn.SetActive(false);
        //   RifleGunspawn.SetActive(true);
        //   Rifleimage.enabled = true;
        //   Machinegunimage.enabled = false;
        //   }
        //}

        // Rifle to machine gun swap

        // ensure when equip next that gun is rifle black other this is the icon image to retrun too
        // not rlevant now auto sl
        //  if (Input.GetButtonDown("Equip Next Item") && MachinegunEquipped)// Y Buttone pressed then machine gun  cancelled to prevent conflict
        //  {
        //   MachinegunEquipped = false;
        //   Machinegunimage.enabled = false;
        //    Machinegun.SetActive(false);
        //    Rifle.SetActive(true); // controlled by group icon
        //    Rifleclip.SetActive(true);
        //    Machinegunspawn.SetActive(false);
        //    RifleGunspawn.SetActive(false);
        //  }

    }

    public void OnTriggerEnter(Collider other)// New to stop NPC on contact with player to avoid push
    {// was an issue here i fived by adding !mgequipped dont want firing here
        if (other.tag == "mgpickup" && !MachinegunEquipped)// Add mg not equippedbool to see if its not equipped 1st*** this fixes
        {//Not enitely sure now stating not mg equipped fixed delay issue guessing it re-inforced otherwise issue
            StartCoroutine(delay2(v: 30));
            Machinegunpickup.SetActive(false);
            Rifleimage.enabled = false;
            Machinegunimage.enabled = true; // new 25/4
            Machinegun.SetActive(true);//test
            Rifle.SetActive(false); // controlled by group icon
            Rifleclip.SetActive(false);
            Machinegunspawn.SetActive(false); //brilliant resolved now with rifle after coroutine 12.5****************
            RifleGunspawn.SetActive(false);
            MachinegunEquipped = true;
            RifleEquip = false;
            Riflepickup.Play();  
        }
        
       // if a fifle is held// still need firing here too
        if (other.tag == "mgpickup" && RifleEquip)// Add mg not equippedbool to see if its not equipped 1st*** this fixes
        {//Not enitely sure now stating not mg equipped fixed delay issue guessing it re-inforced otherwise issue
            StartCoroutine(delay2(v: 30));
            Machinegunpickup.SetActive(false);
            Rifleimage.enabled = false;
            Machinegunimage.enabled = true; // new 25/4
            Machinegun.SetActive(true);//test
            Rifle.SetActive(false); // controlled by group icon
            Rifleclip.SetActive(false);
            Machinegunspawn.SetActive(true); //brilliant resolved now with rifle after coroutine 12.5****************
            RifleGunspawn.SetActive(false);
            MachinegunEquipped = true;
            RifleEquip = false;
        
            //Riflepickup.Play();//initial sound pick up handled by MGpickupscript after 20 sec below warns out of ammo

        }
        
        IEnumerator delay2(int v)  // remove this once level 2 in place
        {
       
            yield return new WaitForSeconds(19.5f);//20 secs of axe time then all reverts to previous// 14/5 changed to start just b4 2o sec so cant get jammed enabled b4 forced anim equipanin
            Rifle.SetActive(true); // controlled by group icon
            Rifleimage.enabled = true;
            Machinegunimage.enabled = false; // new 25/4
            Machinegun.SetActive(false);
            Rifle.SetActive(true); // controlled by group icon
            Rifleclip.SetActive(true);
            Machinegunspawn.SetActive(false);
            RifleGunspawn.SetActive(true);// mg false until equipped Brilliant! reoslved 12/5 issue where kept firing unequpped***
            MachinegunEquipped = false;
            Riflepickup.Play();
            Outofammo.SetActive(true);
            yield return new WaitForSeconds(3.5f);
            Outofammo.SetActive(false);

        }// Machine gun pick up note on trigger only mention once

        if (other.tag == "axepickup")
        {
            StartCoroutine(delay(v: 30));
            AxeEquipped = true;// bool so axe is read but not equipped
            Axeimage.enabled =true;
            Swordimage.enabled = false;
            Axe.enabled = true;
            Sword.enabled = false;// deafault state pick up
            AxeHit.SetActive(false);// basically the switch to axe ability is enalbled for 20 secs
            SwordHit.SetActive(true);
            axepickup.Play();// basically all this mean is the switch to axe ability is enalbled for 20 secs so still has sword until b/y pressed
             Axetextinstructions.SetActive(true);

            IEnumerator delay(int v)  // remove this once level 2 in place
            {
                yield return new WaitForSeconds(3.5f);//
                Axetextinstructions.SetActive(false);
                yield return new WaitForSeconds(19.5f);//20 secs of axe time then all reverts to previous

                Axe.enabled = false;
                Sword.enabled = true;
                Swordimage.enabled = true;// new
                Axeimage.enabled = false;// deafault state pick up
                AxeHit.SetActive(false);
                SwordHit.SetActive(true);
                axepickup.Play();// basically after time axe bility and axe gone and return to sword
                AxeEquipped = false;// bool last order of events check
                Axetext.SetActive(true);
                yield return new WaitForSeconds(2f);
                Axetext.SetActive(false);

            }

            if (other.tag == "rifleequip")// Machine gun pick up note on trigger only mention once
            {
                Rifle.SetActive(true); // controlled by group icon
                Rifleclip.SetActive(true);
                Machinegun.SetActive(false);
                Machinegunspawn.SetActive(false);
                RifleGunspawn.SetActive(true);
                Rifleimage.enabled = true;
                Machinegunimage.enabled = false;
                RifleEquip = true;// this re-inforeced that when rifle equipped the above to  apply
            }// note avoid repeating as caused issues

          }
        }
    }

