using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AccountTable : DataTable
{
    public List<AccountData> dataList = new List<AccountData>();

    public void Load(List<AccountData> dataList)
    {
        this.dataList = dataList;
    }

    public AccountData GetData(int accountId)
    {
        return dataList.FirstOrDefault(data => data.AccountId == accountId);
    }
}


[System.Serializable]
public class AccountData
{
    public int AccountId = 0;
    public int Level = 0;
    public string UserName = string.Empty;
    public int Ranking = 0;
    public string UserDateTime = string.Empty;
    public string UserIp = string.Empty;
    public string UserLoginDateTime = string.Empty;
    public string UserLoginIp = string.Empty;
    public int Hp = 0;
    public int HpRecovery = 0;
    public int ForceRate = 0;

    public int LethalRate = 0;
    public int LethalAtkRate = 0;
    public int Atk = 0;
    public int CriRate = 0;
    public int CriAtk = 0;
    public int AtkAb = 0;
    public int PowerLight = 0;
    public int PowerDark = 0;
    public int PowerFire = 0;
    public int PowerSea = 0;
    public int GoldBonusRate = 0;
    public int ExpBonusRate = 0;
    public int SkillDmgRate = 0;
    public int BossDmgRate = 0;

                                          

}