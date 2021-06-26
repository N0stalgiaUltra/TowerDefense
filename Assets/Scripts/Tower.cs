using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    float fireRate = 2f;
    public float nextFire = 0f;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    void Update()
    {
        nextFire++;

        if(Time.time >= nextFire)
        {
            Fire();
            nextFire = 0f;
        }  
    }

    void Fire()
    {
        //apenas atira ou ataca
        nextFire = Time.time + fireRate;
        GameObject a = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        Destroy(a, 0.5f);
    }
}
