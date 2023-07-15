using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//for health bar ui
using TMPro;




public class ScoreconstantPR : MonoBehaviour// used for desrt level// this script destroy after scorevaule achieved i.e 50 poitn need then stop destroy so does no cause issues accumalte on next level
{

    public static int scoreValue = 0;

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


    
}
