using UnityEngine;
using System.Collections;

public class Moverscript : MonoBehaviour
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
            transform.Translate(Vector3.down * Time.deltaTime * 18);// cancels up movement up to allow cross to right *
            transform.Translate(Vector3.right * Time.deltaTime * speed);// move right

        }

    }
}

