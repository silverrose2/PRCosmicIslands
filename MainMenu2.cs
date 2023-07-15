using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu2 : MonoBehaviour
{

    void Start()//*********** this line code very usefuel takes cursor out
    {
        Cursor.lockState = CursorLockMode.None;// new function needed to be added 31.3 update was able to function without in old version.
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void QuitGame()
    {
        Application.Quit();// back to desk to mob phone device etc
    }

}