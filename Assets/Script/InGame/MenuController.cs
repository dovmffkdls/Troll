using System.Collections ;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoSingleton<MenuController>
{
    int menuPanelStatus = 0;

    [SerializeField] List<RectTransform> menuPanelList = new List<RectTransform>();
    [SerializeField] RectTransform popupParant;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuBtnClick(int index)
    {
        PopupEnum popupEnum = (PopupEnum)index;
        CreatePopup(popupEnum);
    }

    public void CreatePopup(PopupEnum popupEnum) 
    {
        string popupName = string.Empty;

        switch (popupEnum)
        {
            case PopupEnum.ShopPopup: popupName = "ShopPopup";
                break;

            case PopupEnum.pcinfo: popupName = "11_pcinfo";
                break;
        }

        BasePopup basePopup = null;

        if (string.IsNullOrEmpty(popupName) == false)
        {
            basePopup = Instantiate(Resources.Load<BasePopup>("UI/Popup/" + popupName), popupParant);
            basePopup.Init();
        }

        if (basePopup != null )
        {
            //Debug.LogWarning("creat 성공");
        }
        
    }

    public void MenuPanelChangeOn(int status)
    {
        menuPanelStatus = status;

        for (int i = 0; i < menuPanelList.Count; i++)
        {
            menuPanelList[i].gameObject.SetActive(menuPanelStatus == i);
        }
    }
}

public enum PopupEnum
{
    ShopPopup = 0,
    pcinfo = 11,
}
