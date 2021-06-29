using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    float fireRate = 1f;
    public float nextFire;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    void Update()
    {
        if(Time.time > nextFire)
        {
            Fire();
        }  
    }

    void Fire()
    {
        //apenas atira ou ataca
        nextFire = Time.time + fireRate;
        GameObject a = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Destroy(a, 0.5f);
    }
}
