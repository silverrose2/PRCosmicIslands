using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightcontrolPR : MonoBehaviour
{
    public GameObject Heightdamager;
    public GameObject Staticheight;// staticheightcontrolmtfront // be default we want this off until on a platform. this control height damage turning off
    // Start is called before the first frame update
    void Start()
    {
        Heightdamager.SetActive(false);

        Staticheight.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)// action should trigger any time as has if statement
    {
        if (other.gameObject.CompareTag("Player"))//
        {
            Heightdamager.SetActive(true); // if on a height set active
        }
    }
}
    // Update is called once per frame
 