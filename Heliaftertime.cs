using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Boss enters after time
public class Heliaftertime : MonoBehaviour //PR This script I made allows chopper after time to enter 
{
    public GameObject Player;
    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    public GameObject Cloudsheli;
    public GameObject CloudsMain;
    public GameObject CharacterUI;
    public GameObject Maincam;
    public GameObject Introcam;
    public GameObject Heliground;// My logic here is there are 2 helicopters acting as one 1st drop scene then vanishes to allow clean exit
                                 // landed heli appears after 8 seconds remains in the scene for 15 then vanishes. Reason for this is the original is parented to player so synchs with gravity This allow smooth arcade feel.
                                 // so destroying obj and replacing is clean tidy not complex          

    //new heli cam cam update for new view

    void Start()
    {
  
        StartCoroutine(Enableboss(v: 30));
        Introcam.SetActive(true);// comment out to default
        Maincam.SetActive(false);// comment out to default
        CharacterUI.SetActive(false);// Just above crosshair holder
        CloudsMain.SetActive(false);
        CloudsMain.SetActive(false);

    }
    private IEnumerator Enableboss(int v)
    {

        Heliground.SetActive(false);
        yield return new WaitForSeconds(7.0f);// 7.7 for build appears after main heli lands over 8 and but original vanishes to allow clean exit

        CloudsMain.SetActive(true);
        Cloudsheli.SetActive(false);
        CharacterUI.SetActive(true);
        Maincam.SetActive(true);// comment out to default
        Introcam.SetActive(false);//comment out to default
        Heliground.SetActive(true);
        Player.SetActive(true);  // game starts player visible
        Life1.SetActive(true);
        Life2.SetActive(true);
        Life3.SetActive(true);
     
        // stops in game music allowing boss theme
        yield return new WaitForSeconds(16);
        Heliground.SetActive(false); // this 2nd heli vanishes
        CharacterUI.SetActive(true);


    }
}