

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour // this script gets xbox1 trigger working just needs wait for seconds added to prevent repeat
{
    public float moveForce;
    public GameObject bullet;
    public Transform gun;
    public float shootRate;
    public float shootForce;
    private float m_shootRateTimeStamp;
    Animator m_Animator;
    public AudioSource BulletBlast;// audio for shot drag in ************
    private bool m_isAxisInUse = false;
    // too add wait 4 seconds// note *** easier to add a script seprately for z button as theres too much involved and public fields to drag 


    void Update()
    {

        if (Input.GetAxisRaw("Fire1") != 0) // this is for game controller Y button//  if (Input.GetButtonDown("Fire 1"))
        {

            if (m_isAxisInUse == false)

            {
                // Call your event function here.
                m_isAxisInUse = true;
            }


            if (Input.GetAxisRaw("Fire1") == 0)

            {
                m_isAxisInUse = false;
            }


            if (Time.time > m_shootRateTimeStamp && (Input.GetAxisRaw("Fire1") != 0))// 
                                                                                     //originally both triggers were fireing  in error added && (Input.GetAxisRaw("Fire1") != 0)) P.R
            {
                GameObject go = (GameObject)Instantiate(
                bullet, gun.position, gun.rotation);

                go.GetComponent<Rigidbody>().AddForce(gun.forward * shootForce);
                m_shootRateTimeStamp = Time.time + shootRate;
                BulletBlast.Play();//drag in any sound in inspector **************** PR

                if (Input.GetAxisRaw("Fire1") != 0) //&& isEquip)// shot grounded or air 
                {
                    GameObject.Find("(MuzzleFX) Rifle").GetComponent<ParticleSystem>().Play(); //Rifle blast can use setactive Gameobj with play on awake does same ,only option on a coroutine PR
                    GameObject.Find("VisualGunFX").GetComponent<ParticleSystem>().Play();// blue visualgunfxobject with p.s
                                                                                         // BulletBlast.Play();// had this in my old game light fx to disguised and replace basic ball collision bullet
                }

            }

        }

    }

}




