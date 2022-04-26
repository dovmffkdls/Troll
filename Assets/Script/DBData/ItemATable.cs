using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemATable : DataTable
{
    public List<ItemAData> dataList = new List<ItemAData>();

    public void Load(List<ItemAData> dataList)
    {
        this.dataList = dataList;
    }
}


[System.Serializable]
public class ItemAData
{
    public int Id = 0;
    public int ItemNameId = 0;
    public int ItemExplainId = 0;
}

