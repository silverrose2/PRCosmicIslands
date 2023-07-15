using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelselectvariablePR : MonoBehaviour// this takes over after main player dead
{

    [SerializeField]
    private string loadLevel;// This is for portal teleport gets detroyed after used to prevent player repeating teleport on next level

    private int Scoretoconfrim;

  

    void Start()
    {
        
   }
    public void OnTriggerEnter(Collider other)// New to stop NPC on contact with player to avoid push
    {// was an issue here i fived by adding !mgequipped dont want firing here
        if (other.tag == "Player")
        {
            //Cursor.visible = false;
            // StartCoroutine(delay(v: 30));

       // }
        // IEnumerator delay(int v)

        //{
            ScorePR.scoreValue = 0;// each level needs to start 0
                                   //  ScorePR.scoreValue += 80;// ******************** score added simply minus what the required amount to enter the  level was 90 then we are back to 0
            SceneManager.LoadScene(loadLevel);// Variable method public
            Destroy(gameObject);//    // this is likely to be a good fix and prevent unwanted level selection technically as you telport youll still be confirmed as in contact with player and teleporter and
            // yield return new WaitForSeconds(3);
            // SceneManager.LoadScene(4);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            //ScorePR.scoreValue = 0;// each level needs to start 0
           // seeing as each level shares this script you could teleport twice
        }
    }

}






