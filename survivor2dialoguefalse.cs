using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class survivor2dialoguefalse : MonoBehaviour// This is dialogue scrit setting active scene story // also for setting portal entrance false
{
    public TextMeshProUGUI text1;//you found me etc
    public TextMeshProUGUI text2;// get to the copter etc
    public GameObject Takecover;
    public GameObject Survivor2;
    public TextMeshProUGUI Gameover;
    public TextMeshProUGUI Victory;
    // Start is called before the first frame update
    public GameObject Portalentrance;
    public GameObject Proceedtoportal;

    void Start()
    {
        Proceedtoportal.SetActive(false);
        text1.enabled = false;
        text2.enabled = false;
        Takecover.SetActive(false);
        Survivor2.SetActive(false);
        Gameover.enabled = false;
        Victory.enabled = false;
        Portalentrance.SetActive(false);
      
    }
}
