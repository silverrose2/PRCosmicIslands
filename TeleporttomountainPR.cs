using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporttomountainPR : MonoBehaviour
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
            //player.transform.position = new Vector3(34, 7.2F, -1432);// Lake
            player.transform.position = new Vector3(-1112, 407.66f, -291);// mt top
        }
    }
}