using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBTable : DataTable
{
    public List<ItemBData> dataList = new List<ItemBData>();

    public void Load(List<ItemBData> dataList)
    {
        this.dataList = dataList;
    }
}


[System.Serializable]
public class ItemBData
{
    public int Id = 0;
    public int ItemaId = 0;
    public int Grade = 0;
    public int Star = 0;
    public int ItemLv = 0;
    public string InherenceId = string.Empty;
    public string RetentionId = string.Empty;
    public int Hp = 0;
    public int AtkMin = 0;
    public int AtkMax = 0;
    public int CriAtk = 0;
    public int AtkAdd = 0;
    public int Def = 0;
    public int AtkSpeed = 0;
    public int DelayAfterAtk = 0;
    public int BuyGold = 0;
    public int BuyGem = 0;
    public int InvenOverlap = 0;
    public int InvenTime = 0;
    public int LvSafe = 0;
    public int LvLimit = 0;
    public string AffectId = string.Empty;
}
