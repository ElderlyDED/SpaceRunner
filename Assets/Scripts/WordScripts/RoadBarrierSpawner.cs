using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBarrierSpawner : MonoBehaviour
{
    [SerializeField] GameObject MetiorBarrier;
    [SerializeField] GameObject LaserWall;
    [SerializeField] GameObject Turret;
    [SerializeField] GameObject Chest;
    [SerializeField] List<Transform> BarrierSpawnPoints = new List<Transform>();

    [Header("SpawnSpecs")]
    [SerializeField] int SlotsEmpty;
    void Start()
    {
        BarrierSpawnPoints = SpawnPoints(transform, "BarrierPoint");
        SpawnBarriers();
    }
    void Update()
    {
    }
    List<Transform> SpawnPoints(Transform parent, string tag)
    {
        List<Transform> result = new List<Transform>();
        foreach (Transform child in parent.GetComponentInChildren<Transform>())
        {
            if (child.CompareTag(tag))
            {
                result.Add(child);
            }
        }
        return result;
    }
    void SpawnBarriers()
    {
        for (int i = 0; i < SlotsEmpty; i++)
        {
            int RandPointDel = Random.Range(0, BarrierSpawnPoints.Count);
            BarrierSpawnPoints.RemoveAt(RandPointDel);
        }

        foreach (Transform sp in BarrierSpawnPoints)
        {
            int RandomInt = Random.Range(0, 100);
            if (RandomInt > 15)
            {
                InstBarrier(MetiorBarrier, sp);
            }
            else if (RandomInt <= 15 && RandomInt > 2)
            {
                InstBarrier(Turret, sp);
            }
            else if (RandomInt <= 2)
            {
                InstBarrier(Chest, sp);
            }
        }
    }
    void InstBarrier(GameObject BarrierPref, Transform SpawnPoint)
    {
        GameObject InstObj = Instantiate(BarrierPref, SpawnPoint.position, SpawnPoint.rotation);
        InstObj.transform.SetParent(SpawnPoint);
    }
}
