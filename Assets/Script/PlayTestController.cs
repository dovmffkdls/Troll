using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayTestController : MonoBehaviour
{
    [SerializeField] StageController stageController;

    [SerializeField] PlayerSelectItem playerSelectItemPrefab;
    [SerializeField] PlayerSelectItem enumySelectItemPrefab;
    [SerializeField] PlayerSelectItem weaponSelectItemPrefab;
    [SerializeField] PlayerSelectItem mobbSelectItemPrefab;

    [SerializeField] List<Sprite> weaponSpriteList = new List<Sprite>();
    int selectWeaponIndex = 0;

    private AniListData selectEnumyAniData = null;
    [SerializeField] PlayerSelectItem selectEnumyItem;
    [SerializeField] ScrollRect enumyScrollRect;
    [SerializeField] InputField hpAddInput;

    // Start is called before the first frame update
    void Start()
    {
        WeaponListSet();
        PlayerListSet();
        EnumyListSet();
        selectEnumyItem.clickEvent = (data) => enumyScrollRect.gameObject.SetActive(true);
        MobbListSet();
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

    void PlayerSelectOn(PlayerSelectItem selectItem)
    {
        stageController.ChangePlayerCha(selectItem.animData);
        WeaponSelectOn();
    }

    void WeaponListSet()
    {
        List<ItemBData> dataList = CSVDataManager.Instance.itemBTable.dataList;

        for (int i = 0; i < dataList.Count; i++)
        {
            PlayerSelectItem playerSelectItem = Instantiate(weaponSelectItemPrefab, weaponSelectItemPrefab.transform.parent);

            AniListData data = new AniListData();
            data.pcId = i;
            data.pcNameId = dataList[i].ItemaId.ToString();
            playerSelectItem.WeaponDataSet(data);
            playerSelectItem.clickEvent = (selectItem) =>
            {
                selectWeaponIndex = selectItem.animData.pcId;
                WeaponSelectOn();
            };
            playerSelectItem.gameObject.SetActive(true);
        }
    }

    void WeaponSelectOn()
    {
        ItemBData itemBData = CSVDataManager.Instance.itemBTable.dataList[selectWeaponIndex];

        Sprite sprite = weaponSpriteList.FirstOrDefault(data => data.name == itemBData.ItemaId.ToString());

        ChaObjManager.Instance.GetPlayer().WeaponSet(itemBData,sprite);
    }


    void EnumyListSet()
    {
        List<AniListData> enumyDataList = CSVDataManager.Instance.aniListTable.GetListData(1);

        PlayerSelectItem firstSelectItem = null;

        foreach (var data in enumyDataList)
        {
            PlayerSelectItem playerSelectItem = Instantiate(enumySelectItemPrefab, enumySelectItemPrefab.transform.parent);
            playerSelectItem.AniListDataSet(data);
            playerSelectItem.clickEvent = EnumySelectOn;
            playerSelectItem.gameObject.SetActive(true);

            if (firstSelectItem == null)
            {
                firstSelectItem = playerSelectItem;
            }
        }

        EnumySelectOn(firstSelectItem);

        enumyScrollRect.gameObject.SetActive(false);
    }

    void EnumySelectOn(PlayerSelectItem selectItem)
    {
        selectEnumyItem.AniListDataSet(selectItem.animData);
        enumyScrollRect.gameObject.SetActive(false);
        //stageController.CreateEmumy
    }

    void MobbListSet() 
    {
        List<MobBData> mobBDataList = CSVDataManager.Instance.mobBTable.dataList;

        foreach (var data in mobBDataList)
        {
            PlayerSelectItem playerSelectItem = Instantiate(mobbSelectItemPrefab, mobbSelectItemPrefab.transform.parent);
            playerSelectItem.MobBDataSet(data);
            playerSelectItem.clickEvent = MobbSelectOn;
            playerSelectItem.gameObject.SetActive(true);
        }
    }

    void MobbSelectOn(PlayerSelectItem selectItem)
    {
        stageController.CreateEmumy(selectEnumyItem.animData, selectItem);
    }

    public void HPAddBtnClick()
    {
        if (hpAddInput.text == string.Empty)
            return;

        int addHpValue = int.Parse(hpAddInput.text);

        ChaObjManager.Instance.GetPlayer().AddHp(addHpValue);
    }
}
