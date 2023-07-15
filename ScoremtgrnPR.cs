using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//for health bar ui
using TMPro;




public class ScoremtgrnPR : MonoBehaviour// for mountain green level
{


    public static int scoreValue = 0;
    public GameObject Caveentrance;//portal levelselect gameobj
    public GameObject Proceed;//portal levelselect gameobj

    public GameObject Portalcomp1;//portal levelselect gameobj
    public GameObject Portalcomp2;//portal levelselect gameobj
    public GameObject Portalcomp3;//portal levelselect gameobj


    [SerializeField]
    private int scorevaluefield;


    TextMeshProUGUI score;
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
        if (scoreValue > (scorevaluefield))// wil control score all scenes// note postioning of coroutine in relevant area too here is fine i.
        {
            //ScoremtgrnPR.scoreValue += (10);// shouldnt be here oops so can vary oops wrong  this goes on enemy is dead function look carefully here your grabbing a script value sino must have scroemtgrn now
            Caveentrance.SetActive(true);
            Proceed.SetActive(true);// will allow entry to next level after 30 points

            Portalcomp1.SetActive(true);// will allow entry to next level after 30 points
            Portalcomp2.SetActive(true);// will allow entry to next level after 30 points
            Portalcomp3.SetActive(true);// will allow entry to next level after 30 points



            // dont destroy game obj just yet to decide


            // GetComponent<BosshealthPR>().Victory.IsActivetrue);// grabs you boss health component and says game over boss not out til 65 sec
            // next try set boss active so it flows
            // get portal open cave enrtrance
        }

    }
}
