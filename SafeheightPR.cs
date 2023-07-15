using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeheightPR : MonoBehaviour// basically this makes sure static collider only active when on a platform the switches off on exit so player cant radomly jump off edge
    //and still surive the idea here is you have to be on a platform at a safe heght to deacticvate heightdamager.
{
    public GameObject Heightdamager;
    // Start is called before the first frame update
    void Start()
    {
        Heightdamager.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)// action should trigger any time as has if statement
    {
        if (other.gameObject.CompareTag("Player"))//
        {
            Heightdamager.SetActive(false); // if on a height set active
        }
    }
}
// Update is called once per frame
