using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PCInfo_Cha_Upgrade : MonoBehaviour
{
    [SerializeField] List<SMToggleActive> smToggleList = new List<SMToggleActive>();

    [SerializeField] List<RectTransform> tabPanelList = new List<RectTransform>();

    // Start is called before the first frame update
    void Start()
    {
        EventSet();

        smToggleList[0].toggleValue.Value = true;
    }

    void EventSet()
    {
        for (int i = 0; i < smToggleList.Count; i++)
        {
            int index = i;

            smToggleList[i].toggleValue.Subscribe(result => 
            {
                if (result)
                {
                    ToggleClickOn(index);
                }
            });
        }
    }

    public void ToggleClickOn(int index)
    {
        for (int i = 0; i < smToggleList.Count; i++)
        {
            if (index != i)
            {
                smToggleList[i].toggleValue.Value = false;
            }
        }

        TabPanelSet(index);
    }

    void TabPanelSet(int index)
    {
        foreach (var tabPanel in tabPanelList)
        {
            tabPanel.gameObject.SetActive(false);
        }

        tabPanelList[index].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
