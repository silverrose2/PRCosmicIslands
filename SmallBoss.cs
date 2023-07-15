using System.Collections;
using System.Collections.Generic;// pr if you struggle rerefecence   over on this script check upper lower case
using UnityEngine;
using UnityEngine.UI;//for health bar ui
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;

// Had to do seperate boss script as some subtle changes different to usual health also links to players damage to give so made boss damage to give too.
public class SmallBoss : MonoBehaviour// script is for zombies and boss
{
    public GameObject force;// removed on  isdead
    //public GameObject myObject;// PR created a field to drag items to disalbe collider i.e zombie so fulls back under ground
    public int playerMaxHealth;//added health previousley used tag 'player destroyer' for before health was figured out
    public int playerCurrentHealth;
    public Slider healthBar;
    public GameObject Blood;
    // public TextMeshProUGUI Victory;
    bool isDead;//**
                // public GameObject Lootifdead;
                // public GameObject bossdefeatmusic;
                // public GameObject gamemusic;// PRactive music on boss dead( ignore if its not a boss) of turn music volume down if field needs completion
    Animator anim;
   
    void Start()

    {
        Destroy(gameObject, 50);//exits after 50 secs intime for boss 60 sects 10,secs aprox to allow to generate detroy all in spawn *********************************
        Blood.SetActive(false);
        //  Victory.enabled = false;
        // VictoryText.enabled = false;
        // Levelselect.SetActive(false);//selects level index'5' is level2
        anim = GetComponent<Animator>();
        playerCurrentHealth = playerMaxHealth;//added this in for health****
        healthBar.value = playerMaxHealth;//health bar links to above 
        healthBar.value = playerCurrentHealth;
        // Destroy(gameObject, 60);//time for zombies to vanish not relevant for boss just to clear spawns
        // Lootifdead.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
    // line below little confusing, basically damage given health decreases as below function. Obtains damagetogivedata damagetogive script
    public void HurtPlayer(int damageToGive) //added health right up to below**// this is for recieving damage from dtg.
    {
        anim.SetInteger("Condition", 4);// play anim on hurt this is the raptor condition so mastosarus not yet set or needed at this satge
        Blood.SetActive(true);
        playerCurrentHealth -= damageToGive;
        healthBar.value -= damageToGive;// tell the health bar to adjust from damagetogive
        StartCoroutine(delay(v: 30));
    }

    IEnumerator delay(int v)// delay after kick back from hit PR
    {

        yield return new WaitForSeconds(0.2F);// 2 sec hit take then i set back to condition 1 PR 

        {
            anim.SetInteger("Condition", 0); // Back to walk state '0', is 1st anim in state (or any number not assigned) 
            Blood.SetActive(true);
        }
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;//added relating to health
    }

    void OnTriggerEnter(Collider other)
    {
        if (playerCurrentHealth < 0 && !isDead) // added health to reverse put back line below***
                                                // if (other.tag == "Player destroy" && !isDead) // if player is dead 'tag condition' the following function below happen
        {

            StartCoroutine(delay(v: 30));
            isDead = true;// bool for player is dead**// take off fix duration on dead anims 
                          // myObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(GetComponent<Mastonewfollowplayer>());// new method 26/4
            //Destroy(GetComponent<Enemyfollowplayer>());// Stops player moving following 
            Destroy(GetComponent<Randommovement>());//stop random move
           //anim.SetInteger("Condition", 2);// fallbackwards anim error this way fix on just anim play
                                            //anim.Play("Die2");//raptor simply play as anim not branch in state as causes issues for some reason.I need to
            anim.Play("death");//boss
            force.SetActive(false);// icon ability active// new 03/5/23
            ScorePR.scoreValue += (10);
            ScoreconstantPR.scoreValue += (10);

            Destroy(gameObject, 8.00f);// put the function here could put below Inumerator but nice and clean here as no interuption on event PR

        }
        // added a freeze for victory
       IEnumerator delay(int v) // remove this once level 2 in place
       {

          yield return new WaitForSeconds(1.6f);// seconds delay 6 about right // boss falls down suspended to floor PR
          anim.speed = 0;
          gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;// abilty to wonder around off
            // SceneManager.LoadScene(0); // This will take player to 2nd menu/isdead menu (looks the same) but will link to new start game with no error basically alternative level 1 with no cinemachine to cause error on reload.
            //Time.timeScale = 0; //freeze game works 1 is back to play again eventuall replace with scene change
            //yield return new WaitForSeconds(5f);// back to menu
            //anim.speed = 0;// stay put
            //gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;// stay put
             //SceneManager.LoadScene(0); // look at order of events or this function wont work.
       }

    }
}

