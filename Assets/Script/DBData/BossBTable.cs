using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBTable : DataTable
{
    public List<BossBData> dataList = new List<BossBData>();

    public void Load(List<BossBData> dataList)
    {
        this.dataList = dataList;
    }
}

[System.Serializable]
public class BossBData
{
    public int Id = 0;
    public int Type = 0;
    public int Fsm = 0;
    public int Holy = 0;
    public int Star = 0;
    public int Hp = 0;
    public int AtkMin = 0;
    public int AtkMax = 0;
    public int CriRate = 0;
    public int CriAtk = 0;
    public int Pen = 0;
    public int AtkAdd = 0;
    public int DmgReductionFree = 0;
    public int PowerLight = 0;
    public int PowerLightDef = 0;
    public int PowerDark = 0;
    public int PowerDarkDef = 0;
    public int PowerFire = 0;
    public int PowerFireDef = 0;
    public int PowerSea = 0;
    public int PowerSeaDef = 0;
    public int PowerAgility = 0;

    public int Def = 0;
    public int AtkSpeed = 0;
    public int DelayBeforeAtk = 0;
    public int DelayAfterAtk = 0;
    public int GoldMin = 0;
    public int GoldMax = 0;
    public int ExpMin = 0;

    public int ExpMax = 0;
    public string AffectId = string.Empty;
    public string DropRewardId = string.Empty;

}
