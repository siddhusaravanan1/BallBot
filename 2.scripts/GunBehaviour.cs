using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public GameObject player;

    public bool canShoot = false;

    void Start()
    {
        
    }
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if(dist<5)
        {
            transform.LookAt(player.transform.position);
            canShoot = true;
        }
    }
}
