using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBulletScript : MonoBehaviour
{
    [SerializeField] float ShipBulletSpeed;
    void Start()
    {
        transform.Rotate(0, +90, 0);
        StartCoroutine(DelBullet());
    }
    void Update()
    {
        ShipBulletTranslate();
    }
    void ShipBulletTranslate()
    {
        transform.Translate(new Vector3(0, 0, -1) * ShipBulletSpeed * Time.deltaTime);
    }

    IEnumerator DelBullet()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
