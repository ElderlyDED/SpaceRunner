using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class DataManger : MonoBehaviour
{
    public static DataManger instance;
    public int Platinum;
 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (this != instance)
            {
                Destroy(this.gameObject);
            }
        }

    }
    void Start()
    {
    }

    void Update()
    {
    }

    public void MinusPlatinumPlayer(int Minus)
    {
        int PlayerDataPlatinum = PlayerPrefs.GetInt("PDplatinum");
        PlayerDataPlatinum -= Minus;
        PlayerPrefs.SetInt("PDplatinum", PlayerDataPlatinum);
    }

    public void SetData()
    {
        int PlayerDataPlatinum = PlayerPrefs.GetInt("PDplatinum");
        PlayerDataPlatinum += Platinum;
        PlayerPrefs.SetInt("PDplatinum", PlayerDataPlatinum);
    }

    public int GetData()
    {
        return PlayerPrefs.GetInt("PDplatinum");
    }
    public void SetDataUpShield()
    {
        int LvlUpShield = PlayerPrefs.GetInt("PDlvlShield");
        LvlUpShield += 1;
        PlayerPrefs.SetInt("PDlvlShield", LvlUpShield);
    }

    public int GetDataUpShield()
    {
        return PlayerPrefs.GetInt("PDlvlShield");
    }
    
    public void SetDataUpGun()
    {
        int LvlUpGun = PlayerPrefs.GetInt("PDlvlGun");
        LvlUpGun += 1;
        PlayerPrefs.SetInt("PDlvlGun", LvlUpGun);
        
    }

    public int GetDataUpGun()
    {
        return PlayerPrefs.GetInt("PDlvlGun");
    }

    public void SetRecordScoreData(int Score)
    {
        PlayerPrefs.SetInt("RecordScore", Score);
        YandexGame.NewLeaderboardScores("MaxDistanceRun", GetRecordScoreData());
    }

    public int GetRecordScoreData()
    {
        return PlayerPrefs.GetInt("RecordScore");
    }
}
