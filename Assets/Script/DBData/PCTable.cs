using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PCTable : DataTable
{
    public List<PCData> dataList = new List<PCData>();

    public void Load(List<PCData> dataList)
    {
        this.dataList = dataList;
    }

    public PCData GetData(int pcId , int star = 1)
    {
        return dataList.FirstOrDefault(data => data.PcGId == pcId && data.Star == star);
    }
}

[System.Serializable]
public class PCData
{
    public int Id = 0;
    public int PcGId = 0;
    public int PcNameId = 0;
    public int PcExplainId = 0;
    public int Grade = 0;
    public int Star = 0;
    public int EnchantLv = 0;
    public int Holy = 0;
    public int InherenceId = 0;
    public int RetentionId = 0;
    public int Scale = 0;
    public int MotionId = 0;
    public int HpBar = 0;
    public int Hp = 0;
    public int ForceRate = 0;
    public int LethalAtkRate = 0;
    public int Atk1 = 0;
    public int Atk2 = 0;
    public int CriRate = 0;
    public int CriAtk = 0;
    public int AtkRange = 0;
    public int PowerLightRate = 0;
    public int powerLightDef = 0;
    public int PowerDarkRate = 0;
    public int powerDarkDef = 0;
    public int PowerFireRate = 0;
    public int PowerFireDef = 0;
    public int PowerSeaRate = 0;
    public int PowerSeaDef = 0;
    public int Def = 0;
    public int AtkSpeedRate = 0;
    public int MovingSpeed = 0;
    public int CastingSpeedRate = 0;
    public int DmgReduction = 0;
    public int GoldBonusRate = 0;
    public int ExpBonusRate = 0;
    public int SkillDmgRate = 0;
    public int BossDmgRate = 0;
    public int LvSafe = 0;
    public int LvLimit = 0;
}
