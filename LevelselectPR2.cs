using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelselectPR2 : MonoBehaviour// this takes over after main player dead
{
    public void OnTriggerEnter(Collider other)// New to stop NPC on contact with player to avoid push
    {// was an issue here i fived by adding !mgequipped dont want firing here
        if (other.tag == "Player")
        {
            //Cursor.visible = false;
            // StartCoroutine(delay(v: 30));

        }
        // IEnumerator delay(int v)


        {
            // yield return new WaitForSeconds(3);
            SceneManager.LoadScene(5);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            ScorePR.scoreValue = 0;// ech
        }
    }

}






