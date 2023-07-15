using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFXPR : MonoBehaviour // this script gets xbox1 trigger working just needs wait for seconds added to prevent repeat
{// Experimented and got audio for sword swipe manged to chage so immediate swipe sound != to == 26.4.23
    public AudioSource Swordswipe;// drag in roar// new 26.4.23
    private bool m_isAxisInUse = false;

    private void Start()
    {
        Swordswipe = GetComponent<AudioSource>();// new 26.4.23
    }
    void Update()
    {

        if (Input.GetAxisRaw("Fire1") == 0) //*** this is for game controller Y button//  if (Input.GetButtonDown("Fire 1")) changed to ==0
        {

            if (m_isAxisInUse == false)

            {
                // Call your event function here.
                m_isAxisInUse = true;
               // Swordswipe.Play();
            }


            if (Input.GetAxisRaw("Fire1") == 0)

            {
                m_isAxisInUse = false;
                Swordswipe.Play();
            }


            if (Input.GetAxisRaw("Fire1") != 0)// 
                                                                                  
            {
                
                Swordswipe.Play();//drag in any sound in inspector **************** 
            }


        }

    }

}




