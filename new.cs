using UnityEngine;
using System.Collections;

public class Flightmovement : MonoBehaviour
{

    void Update()
    {
        StartCoroutine(Mover(v: 30));

        IEnumerator Mover(int v)// Objects orientation is wrong way round so down is forward

        {
            // by canceling forces
            transform.Translate(Vector3.down * Time.deltaTime * 1000);// Actually moving forwards as my objects orientation is different
            yield return new WaitForSeconds(18.0f);

            transform.Translate(Vector3.up * Time.deltaTime * 1000);// Cancels movement
            yield return new WaitForSeconds(0f);

            transform.Translate(Vector3.back * Time.deltaTime * 100);// Lands
            yield return new WaitForSeconds(6.5f);
            transform.Translate(Vector3.forward * Time.deltaTime * 100);// Freezes with sleight shake


        }

    }
}