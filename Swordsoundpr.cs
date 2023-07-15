using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsoundpr : MonoBehaviour
{// I have added co routine to avoid double audio out put
    public AudioSource Swordswipe;// drag in slash 1// new 26.4.23
    private void Start()// solution intoduced a trigger to sword for audio so only plays when collider hit as opposed to button pressed 
                        // and used to be acive when unequipped problem resolved PR
    {
        Swordswipe = GetComponent<AudioSource>();// new 26.4.23
    }

    public void OnTriggerExit(Collider other)// New to stop NPC on contact with player to avoid push
    {
        if (other.tag == "Swordaudio" && Input.GetAxisRaw("Fire1") != 0) // Combining x 2 ensures sound wont randomly play when colliders move

        {
            StartCoroutine(delay(v: 30));// set delay function in motion
            Swordswipe.enabled = true;
            Swordswipe.Play();

            // to avoid possilbe double replay when held
        }

        IEnumerator delay(int v) // need to switch off respawn
        {
            yield return new WaitForSeconds(0.3f);// I added this in to avioid the possibility of a double sound, out put for sound limited to 0.3
            Swordswipe.enabled = false;// sound off until trigger pulled again o.3 spot on
        }
    }
}
