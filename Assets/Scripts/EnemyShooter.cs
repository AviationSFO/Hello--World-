using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    float shotTimer = 0;
    public GameObject enemyBullet;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer += Time.deltaTime;
        if(shotTimer > 3)
        {
            shotTimer = 0;
            if(Vector3.Distance(this.transform.position, player.transform.position) <= 10) {
                Instantiate(enemyBullet, this.transform.position, this.transform.rotation);
            }
        }
    }
}
