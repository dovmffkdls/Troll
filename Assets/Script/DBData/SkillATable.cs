using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillATable : DataTable
{
    public List<SkillAData> dataList = new List<SkillAData>();

    public void Load(List<SkillAData> dataList)
    {
        this.dataList = dataList;
    }
}
[System.Serializable]
public class SkillAData
{
    public int Id = 0;
    public int SkillNameId = 0;
    public int SkillExplainId = 0;
    public int IconId = 0;
}
