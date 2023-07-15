using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour

{

    public GameObject theEnemy;

    public int xPos;
    public int zPos;
    public int enemyCount;

    // *****Please dont attach this directly to an enemy, the script needs to be attached to an empty game object named, say spawner****
    // note I'm pretty much spawning accross the entire area but you can zone in on the say the barn by plotting out x,z co-ordinates y is height so probably can leave that at 0.30f

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        theEnemy.SetActive(false);//new delay for spawn pr
        //**********************************************************update
        yield return new WaitForSeconds(15);//new delay for spawn pr// note 35 is last default cout changed to 15 7.4.23
        //55 last default count
        while (enemyCount < 7)//x3 spawns// 125, 250 default how many enemies you need 300 is really enough or too much after that you cant move
        {
            theEnemy.SetActive(true);//new delay for spawn // note plotting below simple use cube to take measurements
            yield return new WaitForSeconds(0.01f);
            xPos = Random.Range(-300, 400);//-40,50 //plot out a square where the spawn is try large area x 0,70 , z 0,-40 use a gameobject to measure
            zPos = Random.Range(-160, -600);// -35,40""// default was -50,30 t
            Instantiate(theEnemy, new Vector3(xPos, 0.00f, zPos), Quaternion.identity);// 0 = y pos, quat euler=rot postion if needed.
            yield return new WaitForSeconds(0.1f);//10th of second default was fast 0.1f /0.5ftime to place enemies, 2f last def 
            enemyCount += 1;// the repeater i.e add 1 until reaching say 100 enemies leave at 1 
                            //default height was 0.30f

        }
    }// Instantiate(theEnemy, new Vector3(xPos, 0.00f, zPos), Quaternion.Euler(0, 180f, 0))// for rotation this line can be used, will cause delay at start in Nav agent

}// 

//  xPos = Random.Range(12, 20); //plot out a square where the spawn is try large area x 0,70 , z 0,-40
//zPos = Random.Range(-20,-40) this is enough to cover the barn area

//  xPos = Random.Range(0, 70); //plot out a square where the spawn is try large area x 0,70 , z 0,-40 for total area
//zPos = Random.Range(0,-40);// """"
// f = decimal
//Quaternion.Euler(0, 180f, 0)) rotates enemy if needed some prefabs are actually facing the other way so useful.

// for the boss script please look up Zombiesboss in assets folder the bossscript will trigger new scene

