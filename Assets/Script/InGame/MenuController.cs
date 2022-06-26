using System.Collections ;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    int menuPanelStatus = 0;

    [SerializeField] List<RectTransform> menuPanelList = new List<RectTransform>();

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
        Debug.LogWarning(index);
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
