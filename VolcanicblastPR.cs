using UnityEngine;
using System.Collections;

public class VolcanicblastPR : MonoBehaviour
{
    public float speed;


    void Update()
    {
        StartCoroutine(Mover(v: 30));

        IEnumerator Mover(int v)// remove private re-arranged for putting intop void update

        {
            // by canceling forces i.e down force 20 from the up will cancel out the move.
            yield return new WaitForSeconds(1);
            transform.Translate(Vector3.up * Time.deltaTime * speed);// move up 6 seconds
            yield return new WaitForSeconds(6);//
            Destroy(gameObject);

        }

    }
}

