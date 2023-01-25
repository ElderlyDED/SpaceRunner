using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [Header("SkillsPrefabs")]
    [SerializeField] GameObject ShieldPrefab;
    [SerializeField] GameObject ShipGun;
    [Header("SkillActivTime")]
    [SerializeField] float ActivTimeShield;
    public bool spawnBullet;
    public float ActivTimeBullet;
    DataManger DM;
    RoadGenerator RG;
    UiManagerScript UMS;

    void Awake()
    {
        PlayerManager.instance = this;
    }
    void Start()
    {
        DM = DataManger.instance;
        TimeActivShieldInLvl();
        TimeActivGunInLvl();
        RG = RoadGenerator.instance;
    }
    void Update()
    {
    }
    public void DiePlayer()
    {
        gameObject.GetComponent<PlayerMovment>().OnOffMove = false;
        gameObject.GetComponent<AudioSource>().Play();
        UiManagerScript.instance.OnOffDieMenu(true);
        RoadGenerator.instance.OnOffSpeed(true);
        if (DM.GetRecordScoreData() < RG.ScoreNow)
        {
            DM.SetRecordScoreData(RG.ScoreNow);
        }
    }
    public void ActivShield()
    {
        UiManagerScript.instance.StartShieldSkillIcon(ActivTimeShield);
        StartCoroutine(ShieldManager());
    }
    public void ActivShipGun()
    {
        UiManagerScript.instance.StartShotSkillIcon(ActivTimeBullet);
        GameObject instGun = Instantiate(ShipGun, transform.position, transform.rotation);
        instGun.transform.SetParent(transform);
    }
    IEnumerator ShieldManager()
    {
        ShieldPrefab.SetActive(true);
        yield return new WaitForSeconds(ActivTimeShield);
        ShieldPrefab.SetActive(false);
    }
    IEnumerator ShotManager()
    {
        ShipGun.SetActive(true);
        spawnBullet = true;
        yield return new WaitForSeconds(ActivTimeBullet);
        spawnBullet = false;
        ShipGun.SetActive(false);
    }
    void TimeActivShieldInLvl()
    {
        int ShieldLvl = DM.GetDataUpShield();
        float TimeActivShieldWithLvl = ActivTimeShield;
        for (int i = 0; i < ShieldLvl; i++)
        {
            TimeActivShieldWithLvl += (TimeActivShieldWithLvl / 100 * 10);
            ActivTimeShield = TimeActivShieldWithLvl;
        }
    }
    void TimeActivGunInLvl()
    {
        int GunLvl = DM.GetDataUpGun();
        float TimeActivGunWithLvl = ActivTimeBullet;
        for (int i = 0; i < GunLvl; i++)
        {
            TimeActivGunWithLvl += (TimeActivGunWithLvl / 100 * 10);
            ActivTimeBullet = TimeActivGunWithLvl;
        }
    }

    public void RespawnPlayer()
    {
        StartCoroutine(NotTriggerPlayerTime());
    }
    IEnumerator NotTriggerPlayerTime() 
    {
        //BoxCollider BoxC = gameObject.GetComponent<BoxCollider>();
        //BoxC.enabled = false;
        ShieldPrefab.SetActive(true);
        yield return new WaitForSeconds(3f);
        ShieldPrefab.SetActive(false);
    }
}
