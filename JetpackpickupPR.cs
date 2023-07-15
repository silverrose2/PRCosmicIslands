using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//NEW 25.4

public class JetpackpickupPR : MonoBehaviour// this pickup implment cancel method using multiple colliders
{// all these exit zones to give the best chance of canelation rather than x 1

    public GameObject Jetpackcancelzone1;
    public GameObject Jetpackcancelzone2;
    public GameObject Jetpackcancelzone3;
    public GameObject Jetpackcancelzone4;
    public GameObject Jetpackcancelzone5;

    public GameObject Jetpackcancelzone6;
    public GameObject Jetpackcancelzone7;
    public GameObject Jetpackcancelzone8;
    public GameObject Jetpackcancelzone9;
    public GameObject Jetpackcancelzone10;
    public GameObject Jetpackcancelzone11;
    public GameObject Jetpackcancelzone12;
    public GameObject Rocketpack;// pickup

    public GameObject Playerrocketpack;

    public GameObject Backpack;// this is not as complex as it looks just a lot of zones to cancel and activate etc did try grouping them

    void Start()// note may want to deactive colider as  will still be there only rendervanishing 
    {

        Jetpackcancelzone1.SetActive(false);// start all confrimed false
        Jetpackcancelzone2.SetActive(false);
        Jetpackcancelzone3.SetActive(false);
        Jetpackcancelzone4.SetActive(false);
        Jetpackcancelzone5.SetActive(false);

        Jetpackcancelzone6.SetActive(false);
        Jetpackcancelzone7.SetActive(false);
        Jetpackcancelzone8.SetActive(false);
        Jetpackcancelzone9.SetActive(false);
        Jetpackcancelzone10.SetActive(false);

        Jetpackcancelzone11.SetActive(false);
        Jetpackcancelzone12.SetActive(false);

        Playerrocketpack.SetActive(false);

        Backpack.SetActive(true);

    }

    public void OnTriggerEnter(Collider other)// New to stop NPC on contact with player to avoid push
    {
        if (other.tag == "Player")
        {
            StartCoroutine(delay(v: 30));
            Rocketpack.SetActive(false);
            Playerrocketpack.SetActive(true);

            Backpack.SetActive(false);

            Jetpackcancelzone1.SetActive(false);// making sure that on start of pick up all cancel coliders are gone
            Jetpackcancelzone2.SetActive(false);
            Jetpackcancelzone3.SetActive(false);
            Jetpackcancelzone4.SetActive(false);
            Jetpackcancelzone5.SetActive(false);

            Jetpackcancelzone6.SetActive(false);
            Jetpackcancelzone7.SetActive(false);
            Jetpackcancelzone8.SetActive(false);
            Jetpackcancelzone9.SetActive(false);
            Jetpackcancelzone10.SetActive(false);

            Jetpackcancelzone11.SetActive(false);
            Jetpackcancelzone12.SetActive(false);

        }
        IEnumerator delay(int v)
        {
            yield return new WaitForSeconds(10.0f);
            Jetpackcancelzone1.SetActive(true);
            Jetpackcancelzone2.SetActive(true);
            Jetpackcancelzone3.SetActive(true);
            Jetpackcancelzone4.SetActive(true);
            Jetpackcancelzone5.SetActive(true);

            Jetpackcancelzone6.SetActive(true);
            Jetpackcancelzone7.SetActive(true);
            Jetpackcancelzone8.SetActive(true);
            Jetpackcancelzone9.SetActive(true);
            Jetpackcancelzone10.SetActive(true);

            Jetpackcancelzone11.SetActive(true);
            Jetpackcancelzone12.SetActive(true);
            yield return new WaitForSeconds(5.0f);// allows time for player to drop before putting ruack sack back 
            Playerrocketpack.SetActive(false);
            Backpack.SetActive(true);

            Destroy(gameObject);

            // should stop jetpack as cancel colliders active
            // yield return new WaitForSeconds(10.0f);// time to allow cancel can be amended to fine tune
            //Jetpackcancelzone.SetActive(false);// should stop jetpack as cancel colliders active
        }
    }
}