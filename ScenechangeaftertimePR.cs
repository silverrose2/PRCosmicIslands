using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenechangeaftertimePR : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Changescene(v: 30));

    }
    private IEnumerator Changescene(int v)
    {


        yield return new WaitForSeconds(75);
        SceneManager.LoadScene(0); // scene changes

    }
}


