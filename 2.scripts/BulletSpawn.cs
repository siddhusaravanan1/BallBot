using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GunBehaviour _gunBehaviour;

    public GameObject bullet;

    bool canShoot = false;
    void Start()
    {
        canShoot = true;
    }
    void Update()
    {
        if(_gunBehaviour.canShoot && canShoot)
        {
            StartCoroutine(canSpawn());
        }
    }
    IEnumerator canSpawn()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        canShoot = false;
        yield return new WaitForSeconds(2.5f);
        canShoot = true;
    }
}
