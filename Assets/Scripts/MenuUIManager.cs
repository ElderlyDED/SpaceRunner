using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PlatinumText;
    [SerializeField] UprageScript US;
    DataManger DM;

    [SerializeField] TextMeshProUGUI ShieldLvl;
    [SerializeField] TextMeshProUGUI ShieldCost;
    [SerializeField] TextMeshProUGUI GunLvl;
    [SerializeField] TextMeshProUGUI GunCost;

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject GuideMenu;
    [SerializeField] GameObject LeaderBoardMenu;

    [SerializeField] TextMeshProUGUI RecordText;
    void Start()
    {
        DM = DataManger.instance;
        RecordText.text = "пейнпд: " + DM.GetRecordScoreData().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        DM.GetData();
        PlatinumText.text = DM.GetData().ToString() + " ок";
        ShieldLvl.text = "LVL: " + US.lvlUpShield;
        ShieldCost.text = US.CostLvlUpShield + " ок";
        GunLvl.text = "LVL: " + US.lvlUpGun;
        GunCost.text = US.CostLvlUpGun + " ок";
    }

    public void StartBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToGuideBtnClick()
    {
        MainMenu.SetActive(false);
        GuideMenu.SetActive(true);
        LeaderBoardMenu.SetActive(false);
    }

    public void GoToMenuPanelBtnClick()
    {
        MainMenu.SetActive(true);
        GuideMenu.SetActive(false);
        LeaderBoardMenu.SetActive(false);
    }

    public void GoToLeaderBoardMenu()
    {
        MainMenu.SetActive(false);
        GuideMenu.SetActive(false);
        LeaderBoardMenu.SetActive(true);
    }
}
