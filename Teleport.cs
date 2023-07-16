using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void OnTriggerEnter(Collider other)// action should trigger any time as has if statement
    {
        if (other.gameObject.CompareTag("Player"))// 
        {
            player.transform.position = new Vector3(12, 15, -350);
        }
    }
}
