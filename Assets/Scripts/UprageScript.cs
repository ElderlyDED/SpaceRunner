using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UprageScript : MonoBehaviour
{
    public int lvlUpShield;
    public int CostLvlUpShield;
    [SerializeField] int StartCostShield;
    [SerializeField] int ProcentUpCost;

    public int lvlUpGun;
    public int CostLvlUpGun;
    [SerializeField] int StartCostGun;
    DataManger DM;

    [SerializeField] AudioSource LvlUpSound;
    [SerializeField] AudioSource NoMoneySound;
    void Start()
    {
        DM = DataManger.instance;
        lvlUpShield = DM.GetDataUpShield();
        lvlUpGun = DM.GetDataUpGun();
        CostShieldPlatinum();
        CostGunPlatinum();
    }
    void Update()
    {
       lvlUpShield = DM.GetDataUpShield();
       lvlUpGun = DM.GetDataUpGun();
    }

    public void UpShieldBtn()
    {
        int PlayerPlat = DM.GetData();
        if (PlayerPlat >= CostLvlUpShield)
        {
            
            DM.MinusPlatinumPlayer(CostLvlUpShield);
            DM.SetDataUpShield();
            CostShieldPlatinum();
            LvlUpSound.Play();
            
        }
        else if (PlayerPlat < CostLvlUpShield)
        {
            NoMoneySound.Play();
            print("Money!!!!!!");
        }
        
    }

    public void UpGunBtn()
    {
        int PlayerPlat = DM.GetData();
        if (PlayerPlat >= CostLvlUpGun)
        {

            DM.MinusPlatinumPlayer(CostLvlUpGun);
            DM.SetDataUpGun();
            CostGunPlatinum();
            LvlUpSound.Play();

        }
        else if (PlayerPlat < CostLvlUpShield)
        {
            NoMoneySound.Play();
            print("Money!!!!!!");
        }
    }
    
    void CostShieldPlatinum() // Метод просчета цены от уровня прокачи улучшения для способности "Щит"
    {
        float CostShield = StartCostShield;
        for (int i = 0; i < lvlUpShield; i++)
        {
            CostShield = CostShield + (CostShield / 100 * ProcentUpCost);
            CostLvlUpShield = (int)CostShield;
        }
    }

    void CostGunPlatinum() // Метод просчета цены от уровня прокачи улучшения для способности "Пушка"
    {
        float CostGun = StartCostGun;
        for (int i = 0; i < lvlUpGun; i++)
        {
            CostGun = CostGun + (CostGun / 100 * ProcentUpCost);
            CostLvlUpGun = (int)CostGun;
        }
    }
}
