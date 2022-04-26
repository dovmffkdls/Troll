using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBTable : DataTable
{
    public List<MapBData> dataList = new List<MapBData>();

    public void Load(List<MapBData> dataList)
    {
        this.dataList = dataList;
    }
}


[System.Serializable]
public class MapBData
{
    public int Id = 0;
    public int MapId = 0;
    public int NameId = 0;
    public int RegenPosition = 0;
    public int RegenTime = 0;
    public int Moba1 = 0;
    public int Mobb1 = 0;

    public int Number1 = 0;
    public int Moba2 = 0;
    public int Mobb2 = 0;
    public int Number2 = 0;
    public int Moba3 = 0;
    public int Mobb3 = 0;
    public int Number3 = 0;
    public int Moba4 = 0;

    public int Mobb4 = 0;
    public int Number4 = 0;
    public int Bossa1 = 0;
    public int Bossb1 = 0;
    public int Bossa2 = 0;
    public int Bossb2 = 0;
    public int Limit = 0;
    public int RewardId = 0;
}

