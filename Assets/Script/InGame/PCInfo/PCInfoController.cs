using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCInfoController : BasePopup
{
    [SerializeField] AccountSetData accountSetData;

    [SerializeField] Image pcIcon;
    [SerializeField] List<Toggle> pcStarToggleList = new List<Toggle>();

    private PCData pcData;
    private PCUserData pcUserData;
    
    [SerializeField] Text pcPartsText;
    [SerializeField] Text pcAbilityText_0;
    [SerializeField] Text pcAbilityText_1;

    int selectIndex = 0;

    [SerializeField] PCInfo_FaceIcon faceIconPrefab;
    [SerializeField] RectTransform faceIconParant;
    private List<PCInfo_FaceIcon> faceIconList = new List<PCInfo_FaceIcon>();

    // Start is called before the first frame update
    void Start()
    {
        AccountDataSet();
        
        FaceIconSet();

        FaceIconClickOn(0);
    }

    void AccountDataSet()
    {
        int accountID = 9000;
        accountSetData.accountData = CSVDataManager.Instance.accountTable.GetData(accountID);

        AccountData data = accountSetData.accountData;

        accountSetData.accountGemText.text = GameDataManager.Instance.gem.ToString();
        accountSetData.accountGoldText.text = GameDataManager.Instance.gold.ToString();

        accountSetData.accountNameText.text = data.UserName;

        accountSetData.accountIDText.text = string.Format("# {0} ", data.AccountId);
        accountSetData.accountLvText.text = data.Level.ToString();
        accountSetData.accountRankingText.text = data.Ranking.ToString();
        accountSetData.accountAtkText.text = data.Atk.ToString();
        accountSetData.accountHPText.text = data.Hp.ToString();

        accountSetData.accountCriText.text = string.Format("{0} %", data.CriRate);
    }

    void PCDataSet()
    {
        pcUserData = GameDataManager.Instance.GetPCUserData(pcData.PcGId);

        for (int i = 0; i < pcStarToggleList.Count; i++)
        {
            bool isOn = pcUserData.star >= (i + 1);

            pcStarToggleList[i].isOn = isOn;
        }

        pcIcon.sprite = Resources.Load<Sprite>("UI/PCinfo/Charater/" + pcData.PcGId);

        int maxPartsCnt = CSVDataManager.Instance.pcUpTable.GetData(pcUserData.star+1).NeedNumber;
        string partsStr = string.Format("{0}/{1}", pcUserData.parts, maxPartsCnt);

        pcPartsText.text = partsStr;
    }

    void FaceIconSet()
    {
        foreach (var faceIcon in faceIconList)
        {
            faceIcon.gameObject.SetActive(false);
        }

        List<PCUserData> pcUserDataList = GameDataManager.Instance.pcUserDataList;

        for (int i = faceIconList.Count; i < pcUserDataList.Count; i++)
        {
            PCInfo_FaceIcon faceIcon = Instantiate(faceIconPrefab, faceIconParant);

            PCData tempPcData = CSVDataManager.Instance.pcTable.GetData(pcUserDataList[i].pcGId , pcUserDataList[i].star);

            if (tempPcData != null)
            {
                faceIcon.SetData(tempPcData, i);

                faceIcon.gameObject.SetActive(true);

                faceIcon.clickEventOn += FaceIconClickOn;

                faceIconList.Add(faceIcon);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FaceIconClickOn(int index)
    {
        selectIndex = index;

        for (int i = 0; i < faceIconList.Count; i++)
        {
            faceIconList[i].SelectOn(i == selectIndex);
        }

        List<PCUserData> pcUserDataList = GameDataManager.Instance.pcUserDataList;
        pcData = CSVDataManager.Instance.pcTable.GetData(pcUserDataList[selectIndex].pcGId);

        PCDataSet();
    }


    public void CloseBtnClick()
    {
        Destroy(gameObject);
    }


}

[System.Serializable]
public class AccountSetData
{
    public AccountData accountData;
    public Text accountGemText;
    public Text accountGoldText;
    public Text accountNameText;
    public Text accountIDText;
    public Text accountLvText;
    public Text accountRankingText;
    public Text accountAtkText;
    public Text accountHPText;
    public Text accountDefText;
    public Text accountCriText;
    public Text accountInternalText;
}