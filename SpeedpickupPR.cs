using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//This script controls the large zone for speed. on contact with shoes pick up turned on

public class SpeedpickupPR : MonoBehaviour// this if for rifle pick up******************************
{
   public GameObject SpeedZone;
   public GameObject Shoes;

    public GameObject Lplayershoesgreen;
    public GameObject Lplayershoesred;

    public GameObject Rplayershoesgreen;
    public GameObject Rplayershoesred;


    void Start()
    {
        Rplayershoesred.SetActive(false);
        Lplayershoesred.SetActive(false);
        SpeedZone.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)// New to stop NPC on contact with player to avoid push
    {
        if (other.tag == "Player")
        {
          //  StartCoroutine(delay(v: 30));
            SpeedZone.SetActive(true);
            Shoes.SetActive(false);
            Lplayershoesred.SetActive(true);
            Rplayershoesred.SetActive(true);
            Lplayershoesgreen.SetActive(false);
            Rplayershoesgreen.SetActive(false);
        }
         

        // IEnumerator delay(int v)
        {
        //    yield return new WaitForSeconds(10); // 10 sec of running
           // SpeedZone.SetActive(false);
        }
    }
}