using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobATable : DataTable
{
    public Dictionary<int, MobAData> dataDic = new Dictionary<int, MobAData>();

    public override void Load(List<Dictionary<string, object>> _datas)
    {
        var dataEnumerator = _datas.GetEnumerator();

        while (dataEnumerator.MoveNext())
        {
            var data = dataEnumerator.Current;

            MobAData info = new MobAData();

            info.id = GetIntValue(data["id"].ToString());
            info.mobId = GetIntValue(data["mobId"].ToString());
            info.motionId = GetIntValue(data["motionId"].ToString());
            info.mobNameId = data["mobNameId"].ToString();
            info.mobExplainId = data["mobExplainId"].ToString();
            info.type = GetIntValue(data["type"].ToString());
            info.boss = GetIntValue(data["boss"].ToString());
            info.fsm = GetIntValue(data["fsm"].ToString());
            info.scale = GetIntValue(data["scale"].ToString());
            info.movingSpeed = GetIntValue(data["movingSpeed"].ToString());
            info.attackRange = GetIntValue(data["attackRange"].ToString());
            info.hpPosition = GetIntValue(data["hpPosition"].ToString());

            dataDic.Add(info.id, info);
        }
    }
}
[System.Serializable]
public class MobAData
{
    public int id = 0;
    public int mobId = 0;
    public int motionId = 0;
    public string mobNameId = string.Empty;
    public string mobExplainId = string.Empty;
    public int type = 0;
    public int boss = 0;
    public int fsm = 0;
    public int scale = 0;
    public int movingSpeed = 0;
    public int attackRange = 0;
    public int hpPosition = 0;
}
