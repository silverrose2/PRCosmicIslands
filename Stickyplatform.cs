using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickyplatform : MonoBehaviour // platform set up as parent
{
    private void OnTriggerEnter(Collider other)// action should trigger any time as has if statement
    {
        if (other.gameObject.CompareTag("Player"))//
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

        private void OnTriggerExit(Collider other)// action should trigger any time as has if statement
        {
            if (other.gameObject.CompareTag("Player"))//
            {
            other.gameObject.transform.SetParent(null);
            }
        }
}
