
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilevanish : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3);//defaul is 5 see how low 
    }
    void OnTriggerEnter(Collider other)
    // can use OnCollisionEnter too 
    {
        //(other.gameObject.name == "Dan")
        if (other.tag == "Enemy")
        // works attached to player
        {
            Destroy(gameObject, 0.0f);
        }
    }
}