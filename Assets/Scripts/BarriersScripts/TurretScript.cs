using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] GameObject TurretBulletPrerf;
    [SerializeField] float TurretReload;
    [SerializeField] float TransformForPlayer;
    [SerializeField] GameObject Player;
    [SerializeField] bool Shot;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        TransformForPlayer = transform.position.x - Player.transform.position.x;
        BulletSpawn();
    }
    void BulletSpawn()
    {
        if (TransformForPlayer > -12 && Shot == false)
        {
            Shot = true;
            gameObject.GetComponent<AudioSource>().Play();
            Instantiate(TurretBulletPrerf, transform.position, Quaternion.identity);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerManager>().DiePlayer();
        }
        if (other.tag == "DestroyBarrier")
        {
            GameObject go = other.gameObject;
            Destroy(go);
            Destroy(this.gameObject);
        }
        if (other.tag == "DestroyBarrierShield")
        {
            Destroy(this.gameObject);
        }
    }
}
