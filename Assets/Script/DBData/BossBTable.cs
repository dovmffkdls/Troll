using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBTable : DataTable
{
    public Dictionary<int, BossBData> dataDic = new Dictionary<int, BossBData>();

    public override void Load(List<Dictionary<string, object>> _datas)
    {
        var dataEnumerator = _datas.GetEnumerator();

        while (dataEnumerator.MoveNext())
        {
            var data = dataEnumerator.Current;

            BossBData info = new BossBData();

            info.id = GetIntValue(data["id"].ToString());
            info.type = GetIntValue(data["type"].ToString());
            info.fsm = GetIntValue(data["fsm"].ToString());
            info.holyType = GetIntValue(data["holyType"].ToString());
            info.star = GetIntValue(data["star"].ToString());
            info.hp = GetIntValue(data["hp"].ToString());
            info.hpRecovery = GetIntValue(data["hpRecovery"].ToString());
            info.shortAttackMin = GetIntValue(data["shortAttackMin"].ToString());
            info.shortAttackMax = GetIntValue(data["shortAttackMax"].ToString());
            info.longAttackMin = GetIntValue(data["longAttackMin"].ToString());
            info.longAttackMax = GetIntValue(data["longAttackMax"].ToString());
            info.criRate = GetIntValue(data["criRate"].ToString());
            info.criAttack = GetIntValue(data["criAttack"].ToString());
            info.delayBeforeAttack = GetIntValue(data["delayBeforeAttack"].ToString());
            info.delayAfterAttack = GetIntValue(data["delayAfterAttack"].ToString());
            info.meeleDefense = GetIntValue(data["meeleDefense"].ToString());
            info.criDefense = GetIntValue(data["criDefense"].ToString());
            info.goldMin = GetIntValue(data["goldMin"].ToString());
            info.goldMax = GetIntValue(data["goldMax"].ToString());
            info.expMin = GetIntValue(data["expMin"].ToString());
            info.expMax = GetIntValue(data["expMax"].ToString());
            info.dropRewardId = GetIntValue(data["dropRewardId"].ToString());

            dataDic.Add(info.id, info);
        }
    }
}

[System.Serializable]
public class BossBData
{
    public int id = 0;
    public int type = 0;
    public int fsm = 0;
    public int holyType = 0;
    public int star = 0;
    public int hp = 0;
    public int hpRecovery = 0;
    public int shortAttackMin = 0;
    public int shortAttackMax = 0;
    public int longAttackMin = 0;
    public int longAttackMax = 0;
    public int criRate = 0;
    public int criAttack = 0;
    public int delayBeforeAttack = 0;
    public int delayAfterAttack = 0;
    public int meeleDefense = 0;
    public int criDefense = 0;
    public int goldMin = 0;
    public int goldMax = 0;
    public int expMin = 0;
    public int expMax = 0;
    public int dropRewardId = 0;
}
