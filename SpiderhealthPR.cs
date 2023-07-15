using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//for health bar ui
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class SpiderhealthPR : MonoBehaviour// 
{
    public GameObject force;// to contol on is dead
    public GameObject Blood;// PR created a field to drag items to disalbe collider i.e zombie so fulls back under ground
    public int playerMaxHealth;//added health previousley used tag 'player destroyer' for before health was figured out
    public int playerCurrentHealth;
    public Slider healthBar;
    bool isDead;//**
                // public GameObject Lootifdead;
                // public GameObject bossdefeatmusic;
                // public GameObject gamemusic;// PRactive music on boss dead( ignore if its not a boss) of turn music volume down if field needs completion
    Animator anim;
    // public Text VictoryText;
    //  public GameObject Levelselect;//giant collider activated triggers next level

    // this is just for a boss if using script on normal player ignore field in inspector
    // object with level 2 load doing this way keeps seperate from generic script
    //i.e we dont want level 2 to load when normal zombie defeated.
    // Start is called before the first frame update
    void Start()
    {
        Blood.SetActive(false);
        // Levelselect.SetActive(false);//selects level index'5' is level2
        anim = GetComponent<Animator>();
        playerCurrentHealth = playerMaxHealth;//added this in for health****
        healthBar.value = playerMaxHealth;//health bar links to above 
        healthBar.value = playerCurrentHealth;
      //  Destroy(gameObject, 50);//time for spiders to vanish set off
                                // Lootifdead.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
    // line below little confusing, basically damage given health decreases as below function. Obtains damagetogivedata damagetogive script
    public void HurtPlayer(int damageToGive) //added health right up to below**// this is for recieving damage from dtg.
    {
        anim.SetInteger("Condition", 4);// play anim on hurt
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
            Blood.SetActive(false);
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
            Destroy(GetComponent<Enemyfollowplayer>());// Stops player moving following ***********************************add back in
            Destroy(GetComponent<Randommovement>());//stop random move
                                                    // myObject.GetComponent<BoxCollider>().enabled = false;
           // anim.SetInteger("Condition",2);// 
            anim.Play("die0");//raptor simply play as anim not branch in state as causes issues for some reason.I need to
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            force.SetActive(false);// icon ability active// new 03/5/23
            ScorePR.scoreValue += 10;// ******************** score added 
            ScoreconstantPR.scoreValue += (10);

            //   Lootifdead.SetActive(true);// connect the player to loot item so not destroyed
            //  Lootifdead.transform.parent = null;//unparents disconects so the loot is not destoryed 
            //  bossdefeatmusic.SetActive(true);//if its a boss etc otherwise leave blank if script fails with blank insert empty object
            //  gamemusic.SetActive(false);//boss theme false if boos
            //   VictoryText.enabled = true;// for boss only ignore otherwise in inpector
            //   Levelselect.SetActive(true);
             Destroy(gameObject, 5.00f);

            // 1 is good number no higher, need to vainish quckly before navmesh causes random spin , nav mesh cant be disabled PR
            // myObject.GetComponent<BoxCollider>().enabled = false;// PR removes collider object falls through floor
            // collider disable function not yet possilbe as rigid body conflicts used and has consistant collider   

        }
        IEnumerator delay(int v) // remove this once level 2 in place
        {

            yield return new WaitForSeconds(1.5f);// seconds delay 6 about right spider lower 1 works time until freeze
            anim.speed = 0;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            //SceneManager.LoadScene(4); // This will take player to 2nd menu/isdead menu (looks the same) but will link to new start game with no error basically alternative level 1 with no cinemachine to cause error on reload.
            //Time.timeScale = 0; //freeze game works 1 is back to play again eventuall replace with scene change
        }

    }
}
// The main zombie has attached loot active on dead..the health relates to dropping loot this script took a while to sort and organise so if you dont
//want all zombies to drop loot when dead to spawn gets tricky - to over come this duplicate the zombie
//named Zombie2_3 UI per spawn, simply drag its attached loot in to a dead zone i.e stick x aix -90 well clear etc PR
