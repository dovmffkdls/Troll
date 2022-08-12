using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PCInfo_FaceIcon : MonoBehaviour
{
    int index = 0;
    public PCData pcData;
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

        for (int i = 0; i < pcStarToggleList.Count; i++)
        {
            bool isOn = pcData.Star >= (i + 1);

            pcStarToggleList[i].isOn = isOn;
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
