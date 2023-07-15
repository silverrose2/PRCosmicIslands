using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelselectmtgrnPR : MonoBehaviour// this takes over after main player dead
{

   // [SerializeField]
  //  private string loadLevel;// This is for portal teleport gets detroyed after used to prevent player repeating teleport on next level

   // private int Scoretoconfrim;

        // this script is just if on contact got to level waslelands

    void Start()
    {
       
    }
    public void OnTriggerEnter(Collider other)// New to stop NPC on contact with player to avoid push
    {// was an issue here i fived by adding !mgequipped dont want firing here
        if (other.tag == "Player")
        {
            Level5ScorePR.scoreValue = 0;
            ScorePR.scoreValue = 0;
            ScoremtgrnPR.scoreValue = 0;
            // SceneManager.LoadScene(loadLevel);  
            SceneManager.LoadScene(7);// direct to wastlands not using generic select

            Destroy(gameObject);
                                
        }
    }

}




