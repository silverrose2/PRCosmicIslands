using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switchlevel : MonoBehaviour// this takes over after main player dead
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine(delay(v: 30));

    }
    IEnumerator delay(int v)


    {
        yield return new WaitForSeconds(19.2f);
        SceneManager.LoadScene(2);
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}

    




