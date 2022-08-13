using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PCUpTable : DataTable
{
    public List<PCUpData> dataList = new List<PCUpData>();

    public void Load(List<PCUpData> dataList)
    {
        this.dataList = dataList;
    }

    public PCUpData GetData(int star, int id = 1)
    {
        if (star < 5)
        {
            return dataList.FirstOrDefault(data => data.Star == star);
        }
        else
        {
            return dataList.FirstOrDefault(data => data.Star == star && data.Id == id);
        }
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
