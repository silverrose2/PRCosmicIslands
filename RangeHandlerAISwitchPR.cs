using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// note this enemy follow script works best alternating with nav mesh random movement. **
public class RangeHandlerAISwitchPR : MonoBehaviour// reer to orig version this has been adapted to work with trees Work well
// there are delay calculation 2 seconds so revert to enemyfollowplayer original if there no trees or just a few. The original version will be sharper and responsive
{

    private Transform player;// this script basically swaps between randowm movement nav ai and follow player nav AI
    private float distance;
    public float maxDistance;

    Animator anim;


    void Update()// void start removed with 2 lines below which were not getting called
    {
        {
            player = GameObject.FindGameObjectWithTag("Playerdetect2").transform;
            anim = GetComponent<Animator>();
        }
        if (Vector3.Distance(player.position, gameObject.transform.position) <= maxDistance)
        {
            FollowPlayer();// links to void follow player
          

        }

        if (Vector3.Distance(player.position, gameObject.transform.position) >= maxDistance)
        {

            GetComponent<EnemyfollowNavtype2PR>().enabled = false;//new 8/3 disable in range**
            GetComponent<Randommovement>().enabled = true;
          
        }

    }

    void FollowPlayer()// what happens
    {

        GetComponent<EnemyfollowNavtype2PR>().enabled = true;// we are heading to player directly and avoiding obstancles on route i.e trees
        GetComponent<Randommovement>().enabled = false;// we are not using wondering type AI here
      


    }
    
    public void OnTriggerEnter(Collider other)// New to stop NPC on contact with player to avoid push/ tree
    {
        if (other.tag == "Playerdetect2")// || other.tag == "Player")// 2 main parts to detecting my player Playerdetect2 tag placed on centre of player allow enemys to detect head on

        {
            //GetComponent<Randommovement>().enabled = false;// all forms ove moment added here to ba canceled out dot want player to crush into player
            //  GetComponent<EnemyfollowNavtype2PR>().enabled = false;
            //GetComponent<MovebeforenavPR>().enabled = false;// was meant to stop on aproach to player but disabling here not a good method
            anim.SetInteger("Condition", 1);

        }
        else
        {
           // anim.SetInteger("Condition", 0);
            // GetComponent<EnemyfollowNavtype2PR>().enabled = true;
            //GetComponent<Randommovement>().enabled = false;// was meant to stop on aproach to player but disabling here not a good method

        }

    }
    public void OnTriggerExit(Collider other)// New to stop NPC EXIT on contact with player to avoid push

    {
        GetComponent<Randommovement>().enabled = false;// confimrs still false in this siutation just exiting should proceed following player not random move
        GetComponent<EnemyfollowNavtype2PR>().enabled = true;// still be in range  kept on true
        anim.SetInteger("Condition", 0);
    }

}



