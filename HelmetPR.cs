using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetPR : MonoBehaviour
{
    public GameObject Helmet;// players attached helmet
    public GameObject Helmetmesh;// visible part to helmet
   

    // Start is called before the first frame update
    void Start()
    {
        Helmet.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Helmet.SetActive(true);
            Destroy(Helmetmesh);
         
        }
    }
}