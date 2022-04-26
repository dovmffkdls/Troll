using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOptionTable : DataTable
{
    public List<ItemOptionData> dataList = new List<ItemOptionData>();

    public void Load(List<ItemOptionData> dataList)
    {
        this.dataList = dataList;
    }
}

[System.Serializable]
public class ItemOptionData
{
    public int ID = 0;
    public string Function = string.Empty;
    public int FunctionNameId = 0;
    public int WeaponOption = 0;
    public int ArmorOption = 0;
    public int NecklaceOption = 0;
    public int RingOption = 0;
}

