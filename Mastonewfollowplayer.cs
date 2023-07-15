using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// note this enemy follow script works best alternating with nav mesh random movement. **
public class Mastonewfollowplayer : MonoBehaviour
{

    private Transform player;
    public float rotSpeed, moveSpeed;
    private float distance;
    public float maxDistance;
    //public AudioSource Roar;// drag in roar

    Animator anim;

    // Start is called before the first frame update Zombie follow scripts
    //handels differently void start taken out and player = GameObject.FindGameObjectWithTag("Playerpickup2").transform;
    //anim = GetComponent<Animator>(); orignially this script failed realised 
    //-that void update must be used as 'void start is ignored after start'


    void Update()// void start removed with 2 lines below which were not getting called
    {
        {
            player = GameObject.FindGameObjectWithTag("Playerdetect2").transform;
            anim = GetComponent<Animator>();
         //   Roar = GetComponent<AudioSource>();// new 26.4.23
            anim = GetComponent<Animator>();
        }
        if (Vector3.Distance(player.position, gameObject.transform.position) <= maxDistance)
        {
            FollowPlayer();
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;//new 8/3 disable in range**
            anim.SetInteger("Condition", 1); //we can add this to perform an attack 
           // Roar.Play();
        }
        //new below added 08.3.23 disable nav mesh when close so player follow can take over
        if (Vector3.Distance(player.position, gameObject.transform.position) >= maxDistance)
        {

            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;//new
            anim.SetInteger("Condition", 0); //we can add this to perform an attack 
        }

    }
    // Update is called once per frame
    void FollowPlayer()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation,
        Quaternion.LookRotation(player.position - transform.position), rotSpeed * Time.deltaTime);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

    }
    public void OnTriggerEnter(Collider other)// New to stop NPC on contact with player to avoid push// added tree avpoid 27/5
    {
        if (other.tag == "Player")//|| other.tag == "tree")

            {
            moveSpeed = 0;// STOP
        }

    }
    public void OnTriggerExit(Collider other)// New to stop NPC EXIT on contact with player to avoid push

    {
        moveSpeed = 7;// RETURN // was 7
    }

}


