using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEchantExcessTable : DataTable
{
    public List<ItemEchantExcessData> dataList = new List<ItemEchantExcessData>();

    public void Load(List<ItemEchantExcessData> dataList)
    {
        this.dataList = dataList;
    }
}
[System.Serializable]
public class ItemEchantExcessData
{
    public int Id = 0;
    public int Rate = 0;
    public float RatePlus = 0;
}
