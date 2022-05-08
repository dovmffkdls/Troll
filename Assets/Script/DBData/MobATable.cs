using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MobATable : DataTable
{
    public List<MobAData> dataList = new List<MobAData>();

    public void Load(List<MobAData> dataList)
    {
        this.dataList = dataList;
    }

    public MobAData GetData(int id) 
    {
        return dataList.FirstOrDefault(data => data.Id == id);
    }
    public MobAData GetDataFromMobGid(int mobGid)
    {
        return dataList.FirstOrDefault(data => data.MobGId == mobGid);
    }

}
[System.Serializable]
public class MobAData
{
    public int Id = 0;
    public int MobGId = 0;
    public string MobNameId = string.Empty;
    public string MobExplainId = string.Empty;
    public int Type = 0;
    public int Boss = 0;
    public int Fsm = 0;
    public int Holy = 0;
    public int Scale = 0;
    public int MotionId = 0;
    public int HpBar = 0;
    public int AtkRange = 0;
}
