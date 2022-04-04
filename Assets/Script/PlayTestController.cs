using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTestController : MonoBehaviour
{
    [SerializeField] PlayerSelectItem playerSelectItemPrefab;
    [SerializeField] PlayerSelectItem enumySelectItemPrefab;

    [SerializeField] StageController stageController;

    // Start is called before the first frame update
    void Start()
    {
        PlayerListSet();
        EnumyListSet();
    }

    void PlayerListSet()
    {
        List<AniListData> playerDataList = CSVDataManager.Instance.aniListTable.GetListData(0);

        foreach (var data in playerDataList)
        {
            PlayerSelectItem playerSelectItem = Instantiate(playerSelectItemPrefab, playerSelectItemPrefab.transform.parent);
            playerSelectItem.AniListDataSet(data);
            playerSelectItem.clickEvent = stageController.ChangePlayerCha;
            playerSelectItem.gameObject.SetActive(true);
        }

        stageController.ChangePlayerCha(playerDataList[0]);
    }

    void EnumyListSet()
    {
        List<AniListData> enumyDataList = CSVDataManager.Instance.aniListTable.GetListData(1);

        foreach (var data in enumyDataList)
        {
            PlayerSelectItem playerSelectItem = Instantiate(enumySelectItemPrefab, enumySelectItemPrefab.transform.parent);
            playerSelectItem.AniListDataSet(data);
            playerSelectItem.clickEvent = stageController.CreateEmumy;
            playerSelectItem.gameObject.SetActive(true);
        }
    }
}
