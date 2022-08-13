using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameDataManager : MonoSingleton<GameDataManager>
{
    public int selectStageId = 1;
    public PCData pcData;

    public bool bgMove = false;

    public int gem = 100;
    public int gold = 1000;

    public List<PCUserData> pcUserDataList = new List<PCUserData>();

    protected override void Init()
    {
        base.Init();

        PCUserDataSet();

        PCDataSet();
    }

    void PCUserDataSet()
    {
        pcUserDataList = new List<PCUserData>()
        {
            new PCUserData(1000,3,31),
            new PCUserData(1001,2,20),
            new PCUserData(1002,3,15),
            new PCUserData(1100,2,17),
            new PCUserData(1101,3,19),
            new PCUserData(1102,2,30),
            new PCUserData(1200,3,28),
            new PCUserData(1201,0,11),
            new PCUserData(1202,0,12),
        };
    }

    public PCUserData GetPCUserData(int pcId)
    {
        return pcUserDataList.FirstOrDefault(data => data.pcGId == pcId);
    }

    void PCDataSet() 
    {
        pcData = CSVDataManager.Instance.pcTable.GetData(1000);
    }
}
