using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurner : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }
    void Update()
    {
        transform.LookAt(player.transform.position);
    }
}
