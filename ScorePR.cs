using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//for health bar ui
using TMPro;


// Dont forget when you want to rely on score for levels selec youll need unique script for each level using this method i. scoremtgrn , score,  say scorerocyleve5 etc

public class ScorePR : MonoBehaviour// used for desrt level// this script destroy after scorevaule achieved i.e 50 poitn need then stop destroy so does no cause issues accumalte on next level
{


    public static int scoreValue = 0;
    public GameObject Caveentrance;//portal levelselect gameobj
    public GameObject Proceed;//portal levelselect gameobj

    [SerializeField]
    private int scorevaluefield;


    TextMeshProUGUI score;

    public GameObject Portalcomp1;//portal levelselect gameobj
    public GameObject Portalcomp2;//portal levelselect gameobj
    public GameObject Portalcomp3;//portal levelselect gameobj

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();// score new************* trsmeshprogui replaces the usual old word Text

      
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score " + scoreValue;// score new ************

     
    }

   // void OnGui()// ON RENDER WONT WORK WITH CO ROUTINES BUT WORKS ITS FOR GUI TEXT
    void OnRenderObject()// void onGui not working but this method does apprently its void OnRenderObject() always works, but it's executed too many times per second.
    //   void OnGui()// update for new text

    {
         if (scoreValue > (scorevaluefield))// wil control score all scenes// note postioning of coroutine in relevant area too here is fine i. did have just 30 added serialize public field
        {
           // ScorePR.scoreValue += (10);// so can vary wrong value here belong on eenemy
            Caveentrance.SetActive(true);
            Proceed.SetActive(true);// will allow entry to next level after 30 points

            Portalcomp1.SetActive(true);// will allow entry to next level after 30 points
            Portalcomp2.SetActive(true);// will allow entry to next level after 30 points
            Portalcomp3.SetActive(true);// will allow entry to next level after 30 points
                                        //   Destroy(gameObject, 1f);


            // GetComponent<BosshealthPR>().Victory.IsActivetrue);// grabs you boss health component and says game over boss not out til 65 sec
            // next try set boss active so it flows
            // get portal open cave enrtrance
        }
       
    }
}
