using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    void Start()
    {
    }
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<AudioSource>().Play();
            int RandomInt = Random.Range(0, 100);
            if (RandomInt >= 51)
            {
                other.GetComponent<PlayerManager>().ActivShield();
            }
            else if (RandomInt <= 50)
            {
                other.GetComponent<PlayerManager>().ActivShipGun();
            }
            DataManger DataManagerScript = DataManger.instance;
            int RandomCountPlat = Random.Range(1, 5);
            DataManagerScript.Platinum += RandomCountPlat;
        }
        Destroy(this.gameObject);
    }
}
