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
        chaManager.ChangePlayerCha(data);
    }

    public void CreateEmumy(AniListData data)
    {
        chaManager.CreateEnumy(data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
