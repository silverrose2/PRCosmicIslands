using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// note this enemy follow script works best alternating with nav mesh random movement. **
public class Enemyavoid : MonoBehaviour
{

    private Transform Enemy;
    public float rotSpeed, moveSpeed;
    private float distance;
    public float maxDistance;

    Animator anim;

    // Start is called before the first frame update Zombie follow scripts
    //handels differently void start taken out and player = GameObject.FindGameObjectWithTag("Playerpickup2").transform;
    //anim = GetComponent<Animator>(); orignially this script failed realised 
    //-that void update must be used as 'void start is ignored after start'


    void Update()// void start removed with 2 lines below which were not getting called
    {
        {
            Enemy = GameObject.FindGameObjectWithTag("Force").transform;// can identify with obj force or enemy chose force as worked better force is simply obj at from suited for force script
            anim = GetComponent<Animator>();// basically in range of other enemy stop 
        }
        if (Vector3.Distance(Enemy.position, gameObject.transform.position) <= maxDistance)
        {
            FollowEnemy();
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;//new 8/3 disable in range**// 
            //    anim.SetInteger("Condition", 1); we can add this to perform an attack 
        }
        //new below added 08.3.23 disable nav mesh when close so player follow can take over
        if (Vector3.Distance(Enemy.position, gameObject.transform.position) >= maxDistance)
        {

            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;//new
            //    anim.SetInteger("Condition", 0); we can add this to perform an attack 
        }

    }
    // Update is called once per frame
    void FollowEnemy()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation,
        Quaternion.LookRotation(Enemy.position - transform.position), rotSpeed * Time.deltaTime);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

    }
    public void OnTriggerEnter(Collider other)// New to stop NPC on contact with other enemy to avoid push
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("tree")) // if (otreether.tag == "Force"|| other.tag == "Enemy") 26/5 added treesneed to add tree tags

        {
            moveSpeed = 0;// Stop enemy movement
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            // anim.enabled = false;

        }

    }

    public void OnTriggerExit(Collider other)// New to stop NPC EXIT on contact with player to avoid push

    {
        moveSpeed = 7;//Return
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;// SET TO TRUE 26.5.2 not false3 Going back to normal!!! fixed
                                                                              // anim.enabled = true;
    }

}// trees also need to be treated as obstacles during avoid as nav mesh is switched offand contains this tree avoid ability 26/5




