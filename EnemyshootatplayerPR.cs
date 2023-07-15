using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyshootatplayerPR : MonoBehaviour
{
    //public NavMeshAgent enemy;
   // public Transform player;
    // Start is called before the first frame update // already have a nav mesh
    [SerializeField] private float timer = 5;
    private float bulletTime;
    public float enemySpeed;

    public GameObject enemyBullet;
    public Transform spawnPoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     //   enemy.SetDestination(player.position);
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletObj, 5.0f);

    }
}
// timer 0.05 to 