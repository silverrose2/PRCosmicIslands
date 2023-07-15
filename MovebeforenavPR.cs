using UnityEngine;
using System.Collections;

public class MovebeforenavPR : MonoBehaviour
{
   // public float speed;


    void Update()
    {
      //  StartCoroutine(Mover(v: 30));

       // IEnumerator Mover(int v)// remove private re-arranged for putting intop void update

        {
            // by canceling forces i.e down force 20 from the up will cancel out the move.
          
            transform.Translate(Vector3.forward * Time.deltaTime * 4);// move up 6 seconds
         //   yield return new WaitForSeconds(4);//
           // transform.Translate(Vector3.back* Time.deltaTime * 4);// move up 6 second
           // Destroy(GetComponent<MovebeforenavPR>());

        }

    }
}

