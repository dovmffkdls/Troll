using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCStatUpTable : DataTable
{
    public List<PCStatUpData> dataList = new List<PCStatUpData>();

    public void Load(List<PCStatUpData> dataList)
    {
        this.dataList = dataList;
    }
}

[System.Serializable]
public class PCStatUpData
{
    public int StatLv = 0;
    public float Hp = 0;
    public int HpLP = 0;
    public float ForceRate = 0;
    public int ForceRateLP = 0;
    public float LethalRate = 0;
    public int LethalRateLP = 0;
    public float LethalAtkRate = 0;
    public int LethalAtkRateLP = 0;
    public float Atk = 0;
    public int AtkLP = 0;
    public float CriRate = 0;
    public int CriRateLP = 0;
    public float CriAtk = 0;
    public int CriAtkLP = 0;
    public float PowerLight = 0;
    public int PowerLightRune = 0;
    public float PowerDark = 0;
    public int PowerDarkRune = 0;
    public float PowerAgilityRate = 0;
    public int PowerAgilityRateRune = 0;
    public float PowerAuthorityRate = 0;
    public int PowerAuthorityRateRune = 0;
    public float GoldBonusRate = 0;
    public int GoldBonusRateStone = 0;
    public float ExpBounsRate = 0;
    public int ExpBounsRateStone = 0;
    public float SkillDmgRate = 0;
    public int SkillDmgRateStone = 0;
    public float BossDmgRate = 0;
    public int BossDmgRateStone = 0;
}
