using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textintro : MonoBehaviour
{
    public GameObject Swordinstructions;
    public GameObject textintro;
    public GameObject Axe;
    public GameObject Rifle;
    public GameObject MGpic;
    public GameObject Sword;
    // Start is called before the first frame update
    void Start()
    {
        Swordinstructions.SetActive(false);
        textintro.SetActive(false);
        Axe.SetActive(false);
        Sword.SetActive(false);
        Rifle.SetActive(false);
        MGpic.SetActive(false);
        StartCoroutine(delay(v: 30));
    }

    // Update is called once per frame
    IEnumerator delay(int v) // remove this once level 2 in place
    {
        yield return new WaitForSeconds(2.5f);
        textintro.SetActive(true);
        yield return new WaitForSeconds(4.5f);// seconds delay 6 about right // boss falls down suspended to floor PR
        textintro.SetActive(false);
        Axe.SetActive(true);
        Sword.SetActive(true);
        Rifle.SetActive(true);
        MGpic.SetActive(true);
        yield return new WaitForSeconds(4f);// actually  2.5 and 4.5 in addition 12
        Swordinstructions.SetActive(true);// disable all icon ??
        yield return new WaitForSeconds(2f);
        Swordinstructions.SetActive(false);
    }
}
