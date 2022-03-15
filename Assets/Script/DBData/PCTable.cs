using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCTable : DataTable
{
    public Dictionary<int, PCData> dataDic = new Dictionary<int, PCData>();

    public override void Load(List<Dictionary<string, object>> _datas)
    {
        var dataEnumerator = _datas.GetEnumerator();

        while (dataEnumerator.MoveNext())
        {
            var data = dataEnumerator.Current;

            PCData info = new PCData();

            info.id = GetIntValue(data["id"].ToString());
            info.pcId = GetIntValue(data["pcId"].ToString());
            info.pcNameId = data["pcNameId"].ToString();
            info.pcExplainId = GetIntValue(data["pcExplainId"].ToString());
            info.star = GetIntValue(data["star"].ToString());
            info.grade = GetIntValue(data["grade"].ToString());
            info.scale = GetIntValue(data["scale"].ToString());
            info.holyType = GetIntValue(data["holyType"].ToString());
            info.hp = GetIntValue(data["hp"].ToString());
            info.hpRecovery = GetIntValue(data["hpRecovery"].ToString());
            info.attackMin = GetIntValue(data["attackMin"].ToString());
            info.attackMax = GetIntValue(data["attackMax"].ToString());
            info.attackSpeed = GetIntValue(data["attackSpeed"].ToString());
            info.delayAfterAttack = GetIntValue(data["delayAfterAttack"].ToString());
            info.criRate = GetIntValue(data["criRate"].ToString());
            info.criAttack = GetIntValue(data["criAttack"].ToString());
            info.meeleDefense = GetIntValue(data["meeleDefense"].ToString());
            info.criDefense = GetIntValue(data["criDefense"].ToString());
            info.movingSpeed = GetIntValue(data["movingSpeed"].ToString());
            info.motionId = GetIntValue(data["motionId"].ToString());
            info.hpPosition = GetIntValue(data["hpPosition"].ToString());

            dataDic.Add(info.id, info);
        }
    }
}

[System.Serializable]
public class PCData
{
    public int id = 0;
    public int pcId = 0;
    public string pcNameId = string.Empty;
    public int pcExplainId = 0;
    public int star = 0;
    public int grade = 0;
    public int scale = 0;
    public int holyType = 0;
    public int hp = 0;
    public int hpRecovery = 0;
    public int attackMin = 0;
    public int attackMax = 0;
    public int attackSpeed = 0;
    public int delayAfterAttack = 0;
    public int criRate = 0;
    public int criAttack = 0;
    public int meeleDefense = 0;
    public int criDefense = 0;
    public int movingSpeed = 0;
    public int motionId = 0;
    public int hpPosition = 0;
}
