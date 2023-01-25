using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManagerScript : MonoBehaviour
{
    public static UiManagerScript instance;
    public GameObject GameUI;

    [SerializeField] int ScoreNowUi;
    [SerializeField] TextMeshProUGUI ScoreTextUI;
    [SerializeField] TextMeshProUGUI PlatinumText;

    [SerializeField] GameObject ShotIconPrefab;
    [SerializeField] GameObject ShieldIconPrefab;
    [SerializeField] Transform SkillBox;
    public float TimeLeftShield;
    public bool start;

    [SerializeField] GameObject DieMenu;
    [SerializeField] TextMeshProUGUI DiePlatinumText;
    [SerializeField] TextMeshProUGUI DieScoreText;

    private void Awake()
    {
        UiManagerScript.instance = this;
    }
    void Start()
    {
    }
    void Update()
    {
        SetScoreTextInUi();
        SetPlatinumInUi();
    }
     public void StartShotSkillIcon(float ActivTimeIcon)
     {
        GameObject obj = Instantiate(ShotIconPrefab);
        obj.GetComponent<SkillsIconFill>().TimeLeftSkill = ActivTimeIcon;
        obj.transform.SetParent(SkillBox);
     }
    public void StartShieldSkillIcon(float ActivTimeIcon)
    {
        GameObject obj = Instantiate(ShieldIconPrefab);
        obj.GetComponent<SkillsIconFill>().TimeLeftSkill = ActivTimeIcon;
        obj.transform.SetParent(SkillBox);
    }

    void SetScoreTextInUi()
    {
        ScoreNowUi = RoadGenerator.instance.ScoreNow;
        ScoreTextUI.text = ScoreNowUi.ToString() + " KM";
        DieScoreText.text = "—◊≈“: " + ScoreNowUi.ToString() + "  Ã";
    }

    void SetPlatinumInUi()
    {
        PlatinumText.text = DataManger.instance.Platinum.ToString() + " œÀ";
        DiePlatinumText.text = "œÀ¿“»Õ¿: " + DataManger.instance.Platinum.ToString();
    }

    public void OnOffDieMenu(bool OnOff)
    {
        DieMenu.SetActive(OnOff);
        GameUI.SetActive(false);
    }
}
