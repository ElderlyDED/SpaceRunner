using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public static RoadGenerator instance;

    [Header("Roads")]
    [SerializeField] bool FirstRoad;
    [SerializeField] private List<GameObject> RoadsPref = new List<GameObject> ();
    [SerializeField] private List <GameObject> RoadsCount = new List<GameObject> ();

    [Header("SpeedSpecs")]
    [SerializeField] float StartSpeed;
    public float NowSpeed;
    [SerializeField] float DopSpeed;
    [SerializeField] float PlusSpeed;
    [SerializeField] int MaxRoadCount;

    [Header("Score")]
    public int ScoreNow;
    [SerializeField] int ScoreStep;
    [SerializeField] int NextScoreStep;

    private void Awake()
    {
        RoadGenerator.instance = this;
    }
    void Start()
    {
        FirstRoad = true;
        ResetLevel();
        NowSpeed = StartSpeed;
    }

    void Update()
    {
        RoadsMove();
        UpSpeed();
    }

    void RoadsMove()
    {
        if (NowSpeed == 0)
        {
            return;
        }
        else
        {
            foreach(GameObject road in RoadsCount)
            {
                road.transform.position += new Vector3(NowSpeed * Time.deltaTime, 0 ,0);
            }
        }
        if(RoadsCount[0].transform.position.x > 15)
        {
            Destroy(RoadsCount[0]);
            RoadsCount.RemoveAt(0);
            CreateNextRoad();
        }
    }

    void ResetLevel()
    {
        NowSpeed = 0;
        while(RoadsCount.Count > 0)
        {
            Destroy(RoadsCount[0]);
            RoadsCount.RemoveAt(0);
        }

        for (int i = 0; i < MaxRoadCount; i++)
        {
            CreateNextRoad();
        }
    }

    void CreateNextRoad()
    {
        if (FirstRoad == true)
        {
            FirstRoad = false;
            GameObject roadPrefNow = RoadsPref[1];
            Vector3 roadPos = Vector3.zero;
            if (RoadsCount.Count > 0)
            {
                roadPos = RoadsCount[RoadsCount.Count - 1].transform.position - new Vector3(10, 0, 0);
                ScoreNow += 1;
                ScoreStep += 1;
            }
            GameObject InstObj = Instantiate(roadPrefNow, roadPos, Quaternion.identity);
            InstObj.transform.SetParent(transform);
            RoadsCount.Add(InstObj);
        }
        else
        {
            int IntElemRoad = Random.Range(0, RoadsPref.Count);
            GameObject roadPrefNow = RoadsPref[IntElemRoad];
            Vector3 roadPos = Vector3.zero;
            if (RoadsCount.Count > 0)
            {
                roadPos = RoadsCount[RoadsCount.Count - 1].transform.position - new Vector3(10, 0, 0);
                ScoreNow += 1;
                ScoreStep += 1;
            }
            GameObject InstObj = Instantiate(roadPrefNow, roadPos, Quaternion.identity);
            InstObj.transform.SetParent(transform);
            RoadsCount.Add(InstObj);
        }
    }
    void UpSpeed()
    {
        if (ScoreStep == NextScoreStep)
        {
            ScoreStep = 0;
            NowSpeed += PlusSpeed;
        }
    }

    public void OnOffSpeed(bool stop)
    {
        if (stop == true)
        {
            DopSpeed = NowSpeed;
            NowSpeed = 0;
        }
        else if(stop == false)
        {
            NowSpeed = DopSpeed;
        }
    }

    void MemSpeed()
    {

    }
}
