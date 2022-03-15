using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpTable : DataTable
{
    public Dictionary<int, ExpData> dataDic = new Dictionary<int, ExpData>();

    public override void Load(List<Dictionary<string, object>> _datas)
    {
        var dataEnumerator = _datas.GetEnumerator();

        while (dataEnumerator.MoveNext())
        {
            var data = dataEnumerator.Current;

            ExpData info = new ExpData();

            info.expId = GetIntValue(data["exp"].ToString());
            info.exp = GetIntValue(data["exp"].ToString());
            info.gold = GetIntValue(data["gold"].ToString());
            info.rewardId = GetIntValue(data["rewardId"].ToString());

            dataDic.Add(info.expId,info);
        }
    }
}

[System.Serializable]
public class ExpData
{
    public int expId = 0;
    public int exp = 0;
    public int gold = 0;
    public int rewardId = 0;
}
