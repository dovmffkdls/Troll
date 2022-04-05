using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTestController : MonoBehaviour
{
    [SerializeField] StageController stageController;

    [SerializeField] PlayerSelectItem playerSelectItemPrefab;
    [SerializeField] PlayerSelectItem enumySelectItemPrefab;
    [SerializeField] PlayerSelectItem weaponSelectItemPrefab;

    [SerializeField] List<Sprite> weaponSpriteList = new List<Sprite>();
    int selectWeaponIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        WeaponListSet();
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
            playerSelectItem.clickEvent = PlayerSelectOn;
            playerSelectItem.gameObject.SetActive(true);
        }

        stageController.ChangePlayerCha(playerDataList[0]);
    }

    void PlayerSelectOn(AniListData data)
    {
        stageController.ChangePlayerCha(data);
        WeaponSelectOn();
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

    void WeaponListSet()
    {
        for (int i = 0; i < weaponSpriteList.Count; i++)
        {
            PlayerSelectItem playerSelectItem = Instantiate(weaponSelectItemPrefab, weaponSelectItemPrefab.transform.parent);

            AniListData data = new AniListData();
            data.pcId = i;
            data.pcNameId = weaponSpriteList[i].name;
            playerSelectItem.WeaponDataSet(data);
            playerSelectItem.clickEvent = (aniData) =>
            {
                selectWeaponIndex = aniData.pcId;
                WeaponSelectOn();
            };
            playerSelectItem.gameObject.SetActive(true);
        }
    }

    void WeaponSelectOn()
    {
        ChaObjManager.Instance.GetPlayer().WeaponSpriteSet(weaponSpriteList[selectWeaponIndex]);
    }
}
