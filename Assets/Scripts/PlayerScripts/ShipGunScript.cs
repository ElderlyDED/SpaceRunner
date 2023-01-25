using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGunScript : MonoBehaviour
{
    [SerializeField] GameObject ShipBulletPref;
    [SerializeField] float ShotTime;
    void Start()
    {
        ShotTime = transform.parent.GetComponent<PlayerManager>().ActivTimeBullet;
        StartCoroutine(SpawnBullet());
        StartCoroutine(Destroythis());
    }
    void Update()
    {
        
    }

    IEnumerator SpawnBullet()
    {
        while (true)
        {
             Instantiate(ShipBulletPref, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.6f);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    IEnumerator Destroythis()
    {
        yield return new WaitForSeconds(ShotTime);
        Destroy(this.gameObject);
    }
}
