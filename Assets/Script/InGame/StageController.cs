using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] BGMoveHelper bgMoveHelper;
    [SerializeField] ChaObjManager chaManager;

    // Start is called before the first frame update
    void Start()
    {
        bgMoveHelper.BGMoveSet(true);
    }

    public void ChangePlayerCha(AniListData data)
    {
        PCData pcData = CSVDataManager.Instance.pcTable.GetData(data.pcId);
        chaManager.ChangePlayerCha(pcData);
    }

    public void CreateEmumy(AniListData aniData , PlayerSelectItem selectItem)
    {
        MobAData mpbaData = CSVDataManager.Instance.mobATable.GetDataFromMobGid(aniData.pcId);
        chaManager.CreateEnumy(mpbaData, selectItem.mobBData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
