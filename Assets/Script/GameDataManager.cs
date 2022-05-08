using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoSingleton<GameDataManager>
{
    public int selectStageId = 1;
    public PCData pcData;

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
