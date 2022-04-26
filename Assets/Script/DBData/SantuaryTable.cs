using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantuaryTable : DataTable
{
    public List<SantuaryData> dataList = new List<SantuaryData>();

    public void Load(List<SantuaryData> dataList)
    {
        this.dataList = dataList;
    }
}


[System.Serializable]
public class SantuaryData
{
    public int SantuaryLv = 0;
    public int AtkRate = 0;
    public int AtkExp = 0;
    public int HpRate = 0;
    public int HpExp = 0;
    public int GoldRate = 0;
    public int GoldExp = 0;
    public int ExpRate = 0;
    public int ExpExp = 0;
}
