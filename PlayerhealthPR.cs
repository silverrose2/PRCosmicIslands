using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//for health bar ui
using UnityEngine.SceneManagement;
using TMPro;
using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Character.Abilities;//new
using Opsive.Shared.Events;// new 26.6.23
// any issue revert to 5/6  note inspector health respawen 4 and 4 values
using Opsive.Shared.StateSystem;
using Opsive.Shared.Camera;// new cam switch
using Opsive.UltimateCharacterController.Camera;// new new cam switch
using Opsive.Shared.Utility;// new new cam switch

public class PlayerhealthPR : MonoBehaviour// tip always call functions in the right order animator funtion b4 condition 1
// I made an error trying to get the death anim to play realising condition 1 called before, anim = GetComponent<Animator>();
{// dont forget on build change timer on heliscript
 // public GameObject Cloneplayer;
 //  public GameObject Deathcamera;
 //public GameObject Textintro;//new 9.05.23 
 // Note update added height damage any issues revert to 17 june save in note on updates ind impr as healthbeforeheight dmge 17 june
    // public GameObject Rifle;

    [SerializeField] private string loadLevel;// allows manual override each level to manage scenes
    public GameObject Survivor1;
    public int playerMaxHealth;//added health previousley used tag 'player destroyer' for before health was figured out
    public int playerCurrentHealth;
    public Slider healthBar;
    bool isDead;// function to disconect
    Animator anim;
    public TextMeshProUGUI Gameover;
    public TextMeshProUGUI Victory;
    public TextMeshProUGUI Controlmsg;
    public TextMeshProUGUI Takecovermsg;
    // public Text GameOverText;// game over text grag in PR 4.1.23 drag in UI text game over
    // public GameObject Gundisableifdead;
    //new 02.02.23 allow victroty text end of level
    //  public GameObject Loadlevel2;

    [Tooltip("Femalefighter2")]// Opsive API ref
    [SerializeField] protected GameObject m_Character;// Opsive API ref
    public int Livesdeducted = 0;// new


    public GameObject Player;// To vanish at start 

    public GameObject Heightdamage;// new damage from height set active false on start

    public GameObject Life1;//
    public GameObject Life2;//
    public GameObject Life3;// new


    private int Healthtogive;// made vairable but not public as its a fixed number wich a calculation

    public int Applehealth;// just an empty number to work with

    public GameObject Enemyshootercontrol;// when player dead enemy needs to stop fire to prevent further damage on respawn drag enemy bullet in here gets dsiabled   


    void Start()
    {

      


        Enemyshootercontrol.SetActive(true);
        Player.SetActive(false);
        Gameover.enabled = false;
        Victory.enabled = false;
        isDead = false;// this fixes 28.1 really struggled player kept deactivating on start this is the fix!! is dead false on start of course
        Heightdamage.SetActive(false);             // anim.SetInteger("Condition", 1);//test
      
        // Cursor.visible = false;// curor false by default pay attention here as no curser= no ui function. cursor must be acive in main menu script.
        // GameObject.FindGameObjectWithTag("Femalefighter2Death").SetActive(false);

        //anim.Play("DieBwd");//boss
        // Loadlevel2.SetActive(false);//enemy boss health for set true
        //

        isDead = false;// this fixes 28.1 really struggled player kept deactivating on start this is the fix!! is dead false on start of course
        // anim.SetInteger("Condition", 1);//test
        // GameObject.FindGameObjectWithTag("GameOver").SetActive(false);// game over 04.1.23 pr
        // GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");// 04.1.23 pr to access to disable player
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        // GameOverText.enabled = false;// set to false on start 
        anim = GetComponent<Animator>();
        playerCurrentHealth = playerMaxHealth;//added this in for health****
        healthBar.value = playerMaxHealth;//health bar links to above 
        healthBar.value = playerCurrentHealth;
        //GetComponent<UltimateCharacterLocomotion>().GravityAmount=(2f);//.gravity(8); ******************* Gravity control


        // anim.SetInteger("Condition", 1); 
        //test
    }

    // Update is called once per frame
    void Update()

    {


        {


            Healthtogive = playerCurrentHealth - playerMaxHealth;// new  always being caluculated  not just on start as changes. Basically I added this as a method to caclulate rather than just apply healh
        }// by looking at the 2 varialbes decalred playermax health and player current health I used this to form the calculation. PR This part is my idea implmented to avoid going over max.

        if (Input.GetKeyDown(KeyCode.Escape))// format for input on key down .A,.B,.Escape, etc...
        {
            SceneManager.LoadScene(0);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

        }
        if (Input.GetKeyDown(KeyCode.R))// format for input on key down .A,.B,.Escape, etc...
        {
            Cursor.visible = true;// set cursor on
        }
        if (Input.GetKeyDown(KeyCode.T))// format for input on key down .A,.B,.Escape, etc...
        {
            Cursor.visible = false;// set cursor off
        }
    }
    public void HurtPlayer(int damageToGive) //added health right up to below**
    {
        playerCurrentHealth -= damageToGive;
        healthBar.value -= damageToGive;// tell the health bar to adjust from damagetogive
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;//added relating to health// I think this means we are saving the current health on start as playersmaxhealth 
    }

    void OnTriggerEnter(Collider other)// Made changes below as new text seems to work different*************************
    {
        //(other.gameObject.name == "Dan")
        if (other.tag == "Apple" && playerCurrentHealth < 1000)
        {

            GetComponent<PlayerhealthPR>().HurtPlayer(Healthtogive);//Th take off other as its now part of health is  a calculation now going on

        }


        if (playerCurrentHealth < 0 && !isDead) // added health to reverse put back line below***
                                                // if (other.tag == "Player destroy" && !isDead) // if player is dead 'tag condition' the following function below happen
        {

            {
                var camera = CameraUtility.FindCamera(null);
                if (camera == null)
                {
                    return;
                }

                var cameraController = camera.GetComponent<CameraController>();
                cameraController.Character = m_Character;
                cameraController.SetPerspective(false); // false indicates the third person perspective.

                // Switch to the third person Combat View Type.
                var viewTypeName = "Opsive.UltimateCharacterController.ThirdPersonController.Camera.ViewTypes.LookAt";
                cameraController.SetViewType(TypeUtility.GetType(viewTypeName), false);
                StateManager.SetState(m_Character, "LookAtPresetrose", true);

               // EventHandler.ExecuteEvent(Player, "OnEnableGameplayInput", false);// ****new freeze player input
                var characterLocomotion = m_Character.GetComponent<UltimateCharacterLocomotion>();//Opsive API ref
                var dieAbility = characterLocomotion.GetAbility<Die>();
                // Tries to start the jump ability. There are many cases where the ability may not start, 
                // such as if it doesn't have a high enough priority or if CanStartAbility returns false.
                characterLocomotion.TryStartAbility(dieAbility);//Opsive API ref


                StartCoroutine(delay(v: 30));// set delay function in motion
                                             //  Gameover.enabled = true;// text to annouce game over

                Livesdeducted += 1 * 1;//new
                isDead = true;// bool to indicate the above actions represent is dead.i.e less than 0 and is dead the above events happen was false in error
                Enemyshootercontrol.SetActive(false);
                //This method will work but youd need a way to update current weapons left or zoom in a little so never gets noticed
                // Gundisableifdead.SetActive(false);// stop gun 
                // CharacterController cc = GetComponent<CharacterController>();
                //cc.enabled = false;GameObject.FindGameObjectWithTag("Player").SetActive(false);
                //  EventHandler.ExecuteEvent(Player, "OnEnableGameplayInput", false);// ****new freeze player input
               ScorePR.scoreValue = 0;// **on death value =0 disalbe this is you want to keep the score running also add another if you want x 2 score sytems one for levels one for keeping track remove if needed)

               


            }

            IEnumerator delay(int v) // need to switch off respawn
            {

                yield return new WaitForSeconds(2.3f);// seconds delay 6 about right 2.3 secs works best
                //SceneManager.LoadScene(0);
                //SceneManager.LoadScene(3);//previous method type return to scene o menu once lives is codes use this method 5 lives through game back to menu basically
                // SceneManager.LoadScene(loadLevel);//NEWTYPE IN INSPECTOR use this for now 06/6/23 
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                //SceneManager.LoadScene(4); // This will take player to 2nd menu/isdead menu (looks the same) but will link to new start game with no error basically alternative level 1 with no cinemachine to cause error on reload.
                //Time.timeScale = 0; //freeze game works 1 is back to play again eventuall replace with scene change
                GetComponent<PlayerhealthPR>().HurtPlayer(-1000);
                isDead = false;
                yield return new WaitForSeconds(1.2f);// 1.2 more delay for enemy bullets during death. cant really go high value player timing conflict issues like comes back to life at 1.8f if value set too high may get a way with small values here
                Enemyshootercontrol.SetActive(true);// enemy can no resume with active bullets
                Heightdamage.SetActive(false);// new any issues can move this to lives deducated 1,2,3 
               // EventHandler.ExecuteEvent(Player, "OnEnableGameplayInput", true);// new back to true// 26/6/3****

                var camera = CameraUtility.FindCamera(null);
                if (camera == null)
                {
                   // Can leave blank here
                }

                var cameraController = camera.GetComponent<CameraController>();
                cameraController.Character = m_Character;
                cameraController.SetPerspective(false); // false indicates the third person perspective.

                // Switch to the third person Combat View Type.
                var viewTypeName = "Opsive.UltimateCharacterController.ThirdPersonController.Camera.ViewTypes.Adventure";
                cameraController.SetViewType(TypeUtility.GetType(viewTypeName), false);

                if (Livesdeducted == 1)
                {
                    Life3.SetActive(false);
                    isDead = false;

                   
                }

                if (Livesdeducted == 2)
                {
                    Life2.SetActive(false);
                    isDead = false;
                 

                }

                if (Livesdeducted == 3)
                {
                    Gameover.enabled = true;// text to annouce game over// could put into a new scene 
                    Life1.SetActive(false);
                    isDead = true;
                    ScorePR.scoreValue = 0;//new set o on end game
                    ScoreconstantPR.scoreValue = 0;//new
                    yield return new WaitForSeconds(0.0f);
     
                    SceneManager.LoadScene(loadLevel);
                }
            }

        }
    }
}
//Time.timeScale = 0; //freeze game works 1 is back to play again
// GameObject.FindGameObjectWithTag("Player").SetActive(false);//PR 4.1.23
// GameObject.FindGameObjectWithTag("GameOver").SetActive(true);//PR 4.1.23
//Time.timeScale = 0; //works coroutine needed
// Observe Integer "Condition"/ can be replaced with other wording  Set your chanracters interger 