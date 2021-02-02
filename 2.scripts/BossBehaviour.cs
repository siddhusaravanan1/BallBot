using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBehaviour : MonoBehaviour
{
    bool canShoot = false;

    public GameObject bullet;

    public int health = 50;
    void Start()
    {
        canShoot = true;
    }
    void Update()
    {
        if (canShoot)
        {
            StartCoroutine(canSpawn());
        }
        if(health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
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
