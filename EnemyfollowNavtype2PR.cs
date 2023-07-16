using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;// This is similar to Enemyfollowplayer script used but as opposed to original script takes in to account obstacle avoidance

public class EnemyfollowNavtype2PR : MonoBehaviour
{ 

private Transform playerTransform;
private NavMeshAgent nav;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Playerdetect2").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.destination = playerTransform.position;
    }
}
