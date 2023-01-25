using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class BarrierScript : MonoBehaviour
{
    [SerializeField] List<Mesh> meshes = new List<Mesh>();
    void Start()
    {
        MeshFilter meshMeteor = GetComponent<MeshFilter>();
        int randMesh = Random.Range(0, meshes.Count);
        meshMeteor.mesh = meshes[randMesh];
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
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
