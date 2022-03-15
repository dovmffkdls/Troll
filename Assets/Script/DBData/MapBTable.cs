using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBTable : DataTable
{
    public Dictionary<int, MapBData> dataDic = new Dictionary<int, MapBData>();

    public override void Load(List<Dictionary<string, object>> _datas)
    {
        var dataEnumerator = _datas.GetEnumerator();

        while (dataEnumerator.MoveNext())
        {
            var data = dataEnumerator.Current;

            MapBData info = new MapBData();

            info.id = GetIntValue(data["id"].ToString());
            info.mapId = GetIntValue(data["mapId"].ToString());
            info.nameId = GetIntValue(data["nameId"].ToString());
            info.regenPosition = GetIntValue(data["regenPosition"].ToString());
            info.regenTime = GetIntValue(data["regenTime"].ToString());
            info.mob1 = GetIntValue(data["mob1"].ToString());
            info.number1 = GetIntValue(data["number1"].ToString());
            info.mobb1 = GetIntValue(data["mobb1"].ToString());
            info.mob2 = GetIntValue(data["mob2"].ToString());
            info.number2 = GetIntValue(data["number2"].ToString());
            info.mobb2 = GetIntValue(data["mobb2"].ToString());
            info.mob3 = GetIntValue(data["mob3"].ToString());
            info.number3 = GetIntValue(data["number3"].ToString());
            info.mobb3 = GetIntValue(data["mobb3"].ToString());
            info.mob4 = GetIntValue(data["mob4"].ToString());
            info.number4 = GetIntValue(data["number4"].ToString());
            info.mobb4 = GetIntValue(data["mobb4"].ToString());
            info.boss1 = GetIntValue(data["boss1"].ToString());
            info.bossb1 = GetIntValue(data["bossb1"].ToString());
            info.boss2 = GetIntValue(data["boss2"].ToString());
            info.limit = GetIntValue(data["limit"].ToString());
            info.rewardId = GetIntValue(data["rewardId"].ToString());

            dataDic.Add(info.id, info);
        }
    }
}


[System.Serializable]
public class MapBData
{
    public int id = 0;
    public int mapId = 0;
    public int nameId = 0;
    public int regenPosition = 0;
    public int regenTime = 0;
    public int mob1 = 0;
    public int number1 = 0;

    public int mobb1 = 0;
    public int mob2 = 0;
    public int number2 = 0;
    public int mobb2 = 0;
    public int mob3 = 0;
    public int number3 = 0;
    public int mobb3 = 0;
    public int mob4 = 0;

    public int number4 = 0;
    public int mobb4 = 0;
    public int boss1 = 0;
    public int bossb1 = 0;
    public int boss2 = 0;
    public int bossb2 = 0;
    public int limit = 0;
    public int rewardId = 0;
}

