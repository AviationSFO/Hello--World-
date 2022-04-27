using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public PlayerController pc;
    public GameObject bullet;
    public bool canShoot = false;
    public float shootDelay = 1;
    private float shootTimer = 0;
    public int shotCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Initialized shooter script succesfully");
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time > shootTimer && shotCount % 5 == 0)
        {
            canShoot = true;
        }
        else if(shotCount % 5 != 0)
        {
            canShoot = true;
        }
        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            Instantiate(bullet, this.transform.position, this.transform.rotation);
            shootTimer = Time.time + shootDelay;
            shotCount++;
            canShoot = false;
        }
    }
}
