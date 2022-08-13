using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PCInfo_FaceIcon : MonoBehaviour
{
    int index = 0;
    public PCData pcData;
    private PCUserData pcUserData;

    [SerializeField] RectTransform pcPartsPanel;
    [SerializeField] Text pcPartsText;

    [SerializeField] RectTransform pcStarPanel;
    [SerializeField] List<Toggle> pcStarToggleList = new List<Toggle>();
    [SerializeField] Image faceIcon;

    [SerializeField] RectTransform select_frame;

    public UnityAction<int> clickEventOn = data => { };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(PCData pcData , int index)
    {
        this.index = index;
        this.pcData = pcData;
        faceIcon.sprite = Resources.Load<Sprite>("UI/PCinfo/Face/" + pcData.PcGId);

        pcUserData = GameDataManager.Instance.GetPCUserData(pcData.PcGId);

        bool haveStar = pcUserData.star != 0;

        pcPartsPanel.gameObject.SetActive(!haveStar);
        pcStarPanel.gameObject.SetActive(haveStar);

        if (haveStar == false)
        {
            int maxPartsCnt = CSVDataManager.Instance.pcUpTable.GetData(pcUserData.star + 1).NeedNumber;
            string partsStr = string.Format("{0}/{1}", pcUserData.parts, maxPartsCnt);
            pcPartsText.text = partsStr;
        }
        else
        {
            for (int i = 0; i < pcStarToggleList.Count; i++)
            {
                bool isOn = pcUserData.star >= (i + 1);

                pcStarToggleList[i].isOn = isOn;
            }
        }
    }

    public void ClickOn()
    {
        clickEventOn(index);
    }

    public void SelectOn(bool isOn)
    {
        select_frame.gameObject.SetActive(isOn);
    }
}
