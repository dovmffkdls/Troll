using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPopup : BasePopup
{
    [SerializeField] List<Toggle> tabToggleList = new List<Toggle>();

    private void Awake()
    {
        EventSet();
    }

    void EventSet()
    {
        for (int i = 0; i < tabToggleList.Count; i++)
        {
            int index = i;

            tabToggleList[i].onValueChanged.AddListener(isOn => 
            {
                if (isOn) 
                {
                    TabChangeOn(index);
                }
            });
        }
        
    }

    public void TabChangeOn(int index)
    {
        Debug.LogWarning(index);
    }
}
