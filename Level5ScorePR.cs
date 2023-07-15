using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//for health bar ui
using TMPro;


// Dont forget when you want to rely on score for levels selec youll need unique script for each level using this method i. scoremtgrn , score,  say scorerocyleve5 etc

public class Level5ScorePR : MonoBehaviour// used for desrt level// this script destroy after scorevaule achieved i.e 50 poitn need then stop destroy so does no cause issues accumalte on next level
{


    public static int scoreValue = 0;
  //  public GameObject Ship;//portal levelselect gameobj
    public GameObject Message;//portal levelselect gameobj

    [SerializeField]
    private int scorevaluefield;


    TextMeshProUGUI score;



    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();// score new************* trsmeshprogui replaces the usual old word Text
     //  Ship.SetActive(false);
        Message.SetActive(false);
       
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
            // Level5ScorePR.scoreValue += (10);// so can vary wrong value here belong on eenemy
            StartCoroutine(delay(v: 30));
            //   Ship.SetActive(true);
            Message.SetActive(true);// for seconds


        }

        IEnumerator delay(int v)
        {
            yield return new WaitForSeconds(4);
            Message.SetActive(false);

        }

    }
}
