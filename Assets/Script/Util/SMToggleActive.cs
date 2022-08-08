using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// 오브젝트 활성화 토글 시스템
/// </summary>
public class SMToggleActive : MonoBehaviour
{
    [SerializeField] List<MaskableGraphic> targetList = new List<MaskableGraphic>();
     
    public BoolReactiveProperty toggleValue = new BoolReactiveProperty(false);

    private void Awake()
    {
        EventSet();
    }

    void EventSet()
    {
        toggleValue.Subscribe(result =>
        {
            SetActive();
        });
    }

    void SetActive()
    {
        foreach (var target in targetList)
        {
            target.gameObject.SetActive(toggleValue.Value);
        }
    }

    public void ToggleOn()
    {
        toggleValue.Value = !toggleValue.Value;
    }
    
}
