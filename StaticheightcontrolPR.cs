using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticheightcontrolPR : MonoBehaviour
{
    public GameObject Staticheight;
    // Start is called before the first frame update
    void Start()
    {
      Staticheight.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)// action should trigger any time as has if statement
    {
        if (other.gameObject.CompareTag("Player"))//
        {
            Staticheight.SetActive(true); // if on a height set active
        }
    }
        private void OnTriggerExit(Collider other)// action should trigger any time as has if statement
        {
            if (other.gameObject.CompareTag("Player"))//
            {
                Staticheight.SetActive(false); // if on a height set active
            }
        }
}
// Update is called once per frame
