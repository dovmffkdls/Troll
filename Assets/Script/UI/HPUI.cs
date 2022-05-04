using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    [SerializeField] Image fgImage;
    [SerializeField] RectTransform forceAreaParant;
    [SerializeField] List<RectTransform> forceAreaImageList = new List<RectTransform>();
    
    // Start is called before the first frame update
    void Start()
    {
        SliderValueSet(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ForceAreaSet(List<float> forceInRateList)
    {
        float xSize = forceAreaParant.sizeDelta.x;

        List<float> xVlaueList = new List<float>();

        xVlaueList.Add(xSize * forceInRateList[0] * 0.01f);
        xVlaueList.Add(xSize - (xSize * forceInRateList[2] * 0.01f));

        for (int i = 0; i < xVlaueList.Count; i++)
        {
            Vector3 pos = forceAreaImageList[i].anchoredPosition3D;
            pos.x = xVlaueList[i];
            forceAreaImageList[i].anchoredPosition3D = pos;
        }

        forceAreaParant.gameObject.SetActive(true);
    }

    public void SliderValueSet(float sliderValue)
    {
        fgImage.fillAmount = sliderValue;

        if (sliderValue == 0)
        {
            Destroy(gameObject);
        }
    }
}
