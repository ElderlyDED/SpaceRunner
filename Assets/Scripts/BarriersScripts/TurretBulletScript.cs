using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletScript : MonoBehaviour
{
    [SerializeField] float BulletSpeed;
    void Start()
    {
        StartCoroutine(DelBullet()); 
    }
    void Update()
    {
        MoveBullet();
    }
    void MoveBullet()
    {
        transform.Translate(new Vector3(1, 0, 0) * BulletSpeed * Time.deltaTime);
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
    IEnumerator DelBullet()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
