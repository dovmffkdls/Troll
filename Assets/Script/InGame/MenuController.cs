using System.Collections ;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
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
        CreatePopup(index);
    }

    void CreatePopup(int index) 
    {
        string popupName = string.Empty;

        switch (index)
        {
            case 0: popupName = "ShopPopup";
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
            Debug.LogWarning("creat 성공");
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
