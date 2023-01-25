using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using YG;

public class DieMenuScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI RecordText;
    [SerializeField] GameObject RecordTextObject;
    [SerializeField] int RecordScore;
    [SerializeField] int RecordScore2;
    [SerializeField] DataManger DM;
    [SerializeField] RoadGenerator RG;
    [SerializeField] int AdID;
    [SerializeField] bool ResumePress;
    [SerializeField] GameObject ResumeBtn;
    void Start()
    {
        DM = DataManger.instance;
        RG = RoadGenerator.instance;
        RecordScore = DM.GetRecordScoreData();
        RecordScore2 = RG.ScoreNow;
        
        
    }
    void Update()
    {
        if (DM.GetRecordScoreData() <= RG.ScoreNow)
        {
            RecordTextObject.SetActive(true);
            RecordText.text = "ÍÎÂÛÉ ÐÅÊÎÐÄ: " + DM.GetRecordScoreData();
        }
    }

    

 

    void Reward(int id)
    {
        if (id == AdID)
        {
            void OnEnable() => YandexGame.CloseVideoEvent += Reward;
            ResumeBtnClick();
        }
    }

    public void ResumeBtnClick()
    {
        ResumePress = true;

        PlayerMovment.instance.OnOffMove = true;
        UiManagerScript.instance.OnOffDieMenu(false);
        UiManagerScript.instance.GameUI.SetActive(true);
        RoadGenerator.instance.OnOffSpeed(false);
        PlayerManager.instance.RespawnPlayer();
        offResumeBtn();
        void OnDisable() => YandexGame.CloseVideoEvent += Reward;
    }

    void offResumeBtn()
    {
        if (ResumePress == true)
        {
            ResumeBtn.SetActive(false);
        }
    }

    public void ExitBtnClick()
    {
        DataManger.instance.SetData();
        SceneManager.LoadScene(0);
    }

    public void RestartBtnClick()
    {
        DataManger.instance.SetData();
        GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManger>().Platinum = 0;
        SceneManager.LoadScene(1);
    }


}
