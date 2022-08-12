using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCInfoController : BasePopup
{
    [SerializeField] Text gemText;
    [SerializeField] Text goldText;

    [SerializeField] Image pcIcon;
    [SerializeField] List<Toggle> pcStarToggleList = new List<Toggle>();

    private PCData pcData;

    private List<PCData> havePCDataList = new List<PCData>();

    int selectIndex = 0;

    [SerializeField] PCInfo_FaceIcon faceIconPrefab;
    [SerializeField] RectTransform faceIconParant;
    private List<PCInfo_FaceIcon> faceIconList = new List<PCInfo_FaceIcon>();

    // Start is called before the first frame update
    void Start()
    {
        TempDataSet();

        TextSet();
        
        FaceIconSet();

        FaceIconClickOn(0);
    }

    void TempDataSet()
    {
        List<int> tempIdList = new List<int>()
        {
            1000,1001,1002,1100,1101,1102,1200,1201,1202
        };

        for (int i = 0; i < tempIdList.Count; i++)
        {
            int ranStar = Random.Range(1, 6);
            PCData pcData = CSVDataManager.Instance.pcTable.GetData(tempIdList[i], ranStar);
            havePCDataList.Add(pcData);
        }

        selectIndex = 1;

        pcData = havePCDataList[selectIndex];
    }

    void TextSet()
    {
        gemText.text = GameDataManager.Instance.gem.ToString();
        goldText.text = GameDataManager.Instance.gold.ToString();
    }

    void PCDataSet()
    {
        for (int i = 0; i < pcStarToggleList.Count; i++)
        {
            bool isOn = pcData.Star >= (i + 1);

            pcStarToggleList[i].isOn = isOn;
        }

        pcIcon.sprite = Resources.Load<Sprite>("UI/PCinfo/Charater/" + pcData.PcGId);
    }

    void FaceIconSet()
    {
        foreach (var faceIcon in faceIconList)
        {
            faceIcon.gameObject.SetActive(false);
        }

        for (int i = faceIconList.Count; i < havePCDataList.Count; i++)
        {
            PCInfo_FaceIcon faceIcon = Instantiate(faceIconPrefab, faceIconParant);

            faceIcon.SetData(havePCDataList[i], i);

            faceIcon.gameObject.SetActive(true);

            faceIcon.clickEventOn += FaceIconClickOn;

            faceIconList.Add(faceIcon);
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

        pcData = havePCDataList[selectIndex];

        PCDataSet();
    }


    public void CloseBtnClick()
    {
        Destroy(gameObject);
    }


}
