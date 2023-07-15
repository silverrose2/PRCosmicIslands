using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipvanishesPR : MonoBehaviour
{
    public GameObject Ship;
    // Start is called before the first frame update
    void Start()
    {
        Ship.SetActive(true);
        StartCoroutine(Mover(v: 30));
    }

    IEnumerator Mover(int v)// remove private re-arranged for putting intop void update

    {
        yield return new WaitForSeconds(63.3f);// was 63 scence change allow 0.3 this is the main ship not small ship heading to planet
        Ship.SetActive(false);

    }
}
