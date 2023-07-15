using UnityEngine;
using System.Collections;
using TMPro;// by p.rose// be aware this is shared changes will effect all make new version for variation on new scene

public class HelirescuePR : MonoBehaviour
{
    public float speed;

    public TextMeshProUGUI takecover;//replaced as game obj for detroy after time as had issue here
    public GameObject takecovertext;


    void Start()
    {
        takecovertext.SetActive(false);
    }
    void Update()
    {
        StartCoroutine(Mover(v: 30));

        IEnumerator Mover(int v)// remove private re-arranged for putting intop void update

        {
            // by canceling forces i.e down force 20 from the up will cancel out the move.
            yield return new WaitForSeconds(15);
            transform.Translate(Vector3.up * Time.deltaTime * speed);// move up 6 seconds
            yield return new WaitForSeconds(6);//
            transform.Translate(Vector3.down * Time.deltaTime * 18);// cancels up movement up to allow cross to right *
            transform.Translate(Vector3.right * Time.deltaTime * speed);// move right
            yield return new WaitForSeconds(4);
          // doing this as gameobj as had issues due to limitation on obj disapearing
            yield return new WaitForSeconds(5);
            takecovertext.SetActive(true);
            Destroy(takecovertext, 6);
            Destroy(gameObject, 4);

        }

    }
}

