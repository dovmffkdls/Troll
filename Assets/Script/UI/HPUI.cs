using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    [SerializeField] Image fgImage;

    // Start is called before the first frame update
    void Start()
    {
        SliderValueSet(1);
    }

    // Update is called once per frame
    void Update()
    {
        
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
