using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerhealthboostPR : MonoBehaviour// This scrip attaches to a bullet. ref what bullet is hitting for damage
{// Dont forget tag Enemy in Unity as Enemy *****************************
    public int damageToGive;// access to enemy health pay attention to the upper and lower case formats
  //  public AudioSource Pickupaudio;// drag in
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    //void OnCollisionEnter2D (Collider2D other)
    void OnTriggerEnter(Collider other)
    // can use OnCollisionEnter too 
    {

        //(other.gameObject.name == "Dan")
        if (other.tag == "Player")

        {
            StartCoroutine(delay(v: 30));
        }
        IEnumerator delay(int v)
        {
            yield return new WaitForSeconds(1.4f);
            other.gameObject.GetComponent<PlayerhealthPR>().HurtPlayer(damageToGive);//ThePlayer/ enemy script
                                                                                     //public AudioSource Enemymoan; //this creates a source slot for audio
       //     Pickupaudio.Play();
            Destroy(gameObject, 1.6F);// 1.4 and 1.6 = 2
        }
    }
}