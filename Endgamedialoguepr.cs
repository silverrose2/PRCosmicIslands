using UnityEngine;
using System.Collections;
using TMPro;//
using UnityEngine.SceneManagement;

public class Endgamedialoguepr : MonoBehaviour// This script control when text should be active or false over a time delay
{
    public TextMeshProUGUI Text1;
  
    Vector3 direction;// need to do the same for ai code where i enumerator is used check dialogue text to to see if this is effected and all other parts

    private void Start()
    {
        StartCoroutine(Mover(v: 60));
        Text1.enabled = false;

    }

    void Update()
    {
        

    }

    IEnumerator Mover(int v)//my Objects orientation is wrong way round so down is forward

    {
        Text1.enabled = false;
        yield return new WaitForSeconds(72);// 62 until apraches earth
        Text1.enabled = true;
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);

    }
}





