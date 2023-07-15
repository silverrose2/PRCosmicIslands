using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//NEW 25.4

public class PickupPR : MonoBehaviour// this if for rifle pick up******************************
{
   // public GameObject Icons;
  //  public GameObject Riflecomp1;
   // public GameObject Riflecomp2;


    //public MeshRenderer Axe;// all you need is MeshRender
   
  // public Image Axeimage;
  //  public Image Swordimage;
   // public Image Rifleimage;

    // Start is called before the first frame update
    void Start()
    {
    //    Icons.SetActive(false);
     //  Swordimage.enabled = false;//new
       // Axeimage.enabled = false;//new
      // Rifleimage.enabled = false;//new
    }

    public void OnTriggerEnter(Collider other)// New to stop NPC on contact with player to avoid push
    {
        if (other.tag == "Player")
        {
           //  Icons.SetActive(true);// icon ability active
           // Swordimage.enabled = false;//new
          //   Axeimage.enabled = true;//new
           // Rifleimage.enabled = true;
           // Riflecomp1.SetActive(true);
         //  Riflecomp2.SetActive(true);
            Destroy(gameObject, 0.5f);
        }
    }
}