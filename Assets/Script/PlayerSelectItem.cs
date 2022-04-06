using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerSelectItem : MonoBehaviour
{
    public AniListData animData;
    public MobBData mobBData;
    public UnityAction<PlayerSelectItem> clickEvent;
    [SerializeField] Text nameText;

    public void AniListDataSet(AniListData animData)
    {
        this.animData = animData;
        TextReset();
    }

    public void MobBDataSet(MobBData mobBData)
    {
        this.mobBData = mobBData;
        nameText.text = mobBData.id.ToString();
    }

    void TextReset()
    {
        nameText.text = string.Format("{0} {1}", animData.pcId, animData.pcNameId);
    }

    public void WeaponDataSet(AniListData animData)
    {
        this.animData = animData;
        nameText.text = animData.pcNameId;
    }

    public void BtnClick()
    {
        if (clickEvent != null)
        {
            clickEvent(this);
        }
    }
}
