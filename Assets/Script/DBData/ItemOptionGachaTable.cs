using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOptionGachaTable : DataTable
{
    public List<ItemOptionGachaData> dataList = new List<ItemOptionGachaData>();

    public void Load(List<ItemOptionGachaData> dataList)
    {
        this.dataList = dataList;
    }
}

[System.Serializable]
public class ItemOptionGachaData
{
    public int ID = 0;
    public string Function = string.Empty;
    public int Measure = 0;
    public int Grade1Min = 0;
    public int Grade1Max = 0;
    public float Grade2Min = 0;
    public int Grade2Max = 0;

    public int Grade3Min = 0;
    public int Grade3Max = 0;
    public int Grade4Min = 0;
    public int Grade4Max = 0;
    public int Grade1Rate = 0;
    public int Grade2Rate = 0;
    public int Grade3Rate = 0;
    public int Grade4Rate = 0;
}


