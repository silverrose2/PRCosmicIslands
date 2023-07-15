using UnityEngine;
using System.Collections;

public class Gravitypr : MonoBehaviour
{
    public float speed;
    public GameObject GameObject;

    void Update()
    {
        StartCoroutine(Mover(v: 30));

        IEnumerator Mover(int v)// remove private re-arranged for putting intop void update

        {
            // by canceling forces i.e down force 20 from the up will cancel out the move.
           // yield return new WaitForSeconds(1);
            //transform.Translate(Vector3.up * Time.deltaTime * speed);// move up 6 seconds
            yield return new WaitForSeconds(0);//
            transform.Translate(Vector3.down * Time.deltaTime * 1);// cancels up movement up to allow cross to right *
                                                                    // transform.Translate(Vector3.right * Time.deltaTime * speed);// move right
            yield return new WaitForSeconds(7.6f);
            GameObject.transform.parent = null;

        }

    }
}

