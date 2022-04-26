using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpTable : DataTable
{
    public List<ExpData> dataList = new List<ExpData>();

    public void Load(List<ExpData> dataList)
    {
        this.dataList = dataList;
    }
}

[System.Serializable]
public class ExpData
{
    public int ExpId = 0;
    public int Exp = 0;
    public int Gold = 0;
    public int RewardId = 0;
}
