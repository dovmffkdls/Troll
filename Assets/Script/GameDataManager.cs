using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoSingleton<GameDataManager>
{
    public int selectStageId = 1;
    public PCData pcData;

    public bool bgMove = false;

    public int gem = 100;
    public int gold = 1000;

    protected override void Init()
    {
        base.Init();

        PCDataSet();
    }

    void PCDataSet() 
    {
        pcData = CSVDataManager.Instance.pcTable.GetData(1000);
    }
}
