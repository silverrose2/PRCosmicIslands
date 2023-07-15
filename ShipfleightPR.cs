using UnityEngine;
using System.Collections;

public class ShipfleightPR : MonoBehaviour
{
    public GameObject Clouds1;
    public GameObject Clouds2;
    public GameObject Cam;
    public GameObject Spacecam;


    public GameObject Shipcamlast;
    public GameObject Sea;
    public GameObject Planets;
    Vector3 direction;// need to do the same for ai code where i enumerator is used check dialogue text to to see if this is effected and all other parts
    Vector3 direction2;// speed altered as lands
    Vector3 direction4;
    public GameObject Shipendofgame;
   

    float direction3;// for rotation

    private void Start()
    {
        
        Shipendofgame.SetActive(false);
        Planets.SetActive(false);
        StartCoroutine(Mover(v: 60));
        Clouds2.SetActive(false);
        Clouds1.SetActive(true);
        Cam.SetActive(true);
        Spacecam.SetActive(false);
        Shipcamlast.SetActive(false);
    }


    void Update()
    {
        transform.Translate(direction * Time.deltaTime * 1000);//start
        transform.Translate(direction2 * Time.deltaTime * 100);// slow
        transform.Translate(direction4 * Time.deltaTime * 7000);//  faster speed
        transform.Rotate(0f, 0f * Time.deltaTime, direction3, Space.Self);// Added rotate method

    }


    IEnumerator Mover(int v)//my Objects orientation is wrong way round so down is forward

    {
        yield return new WaitForSeconds(0.3f);// confirm scene change o.3 seems to work 
        direction = Vector3.down;// forward
        yield return new WaitForSeconds(18f);// time moving forward// build delay difference was 18********************
        direction = Vector3.zero;// stops
        yield return new WaitForSeconds(1f);// stop wait time
        direction2 = Vector3.back;// landing
        yield return new WaitForSeconds(5.5f);// time takes to land
        direction3 = (0.5f);// rotation speed of 
        yield return new WaitForSeconds(1.1f);// time takes rotating
        direction2 = Vector3.zero; // stop moving down
        direction3 = (0);// stop rotate

        yield return new WaitForSeconds(12);
        Sea.SetActive(false);
        direction2 = Vector3.forward;// up
        yield return new WaitForSeconds(12);

        direction = Vector3.down;// forward Clouds1.SetActive(false);// med spd
        Clouds2.SetActive(true);
        Clouds1.SetActive(false);
        yield return new WaitForSeconds(2);
        direction2 = Vector3.forward;// up
        yield return new WaitForSeconds(2);
        direction4 = Vector3.down;// forward fastest speed
        Spacecam.SetActive(true);
        Planets.SetActive(true);
        direction = Vector3.zero;// stops d 4 taking over here
        Cam.SetActive(false);
        Clouds1.SetActive(false);
        yield return new WaitForSeconds(1);
        direction = Vector3.zero;// stops
        yield return new WaitForSeconds(5.8f);
        Clouds2.SetActive(false);
        yield return new WaitForSeconds(2.5f);// was 2.5 add 0.3 scene allowance set ship vanish .3 up
        direction = Vector3.zero;// stops
        direction4 = Vector3.zero;
        direction2 = Vector3.zero;
        direction3 = (0);
        Shipendofgame.SetActive(true);
        Spacecam.transform.SetParent(null);// This ensure that when the ship is set active false the camera remains to film outer perspective
       
        yield return new WaitForSeconds(3);

       
    }
}





