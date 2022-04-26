using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCUpTable : DataTable
{
    public List<PCUpData> dataList = new List<PCUpData>();

    public void Load(List<PCUpData> dataList)
    {
        this.dataList = dataList;
    }
}

[System.Serializable]
public class PCUpData
{
    public int Id = 0;
    public int Star = 0;
    public int NeedNumber = 0;
    public int NeedGold = 0;
    public int NextRate = 0;
    public float NextRatePlus = 0;
    public int LimitLevel = 0;
}
