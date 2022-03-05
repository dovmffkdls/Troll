using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMoveHelper : MonoBehaviour
{
    bool bgMoveOn = false;

    [SerializeField] Image bgImage;
    public float bgMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BGMoveSet(bool bgMoveOn)
    {
        this.bgMoveOn = bgMoveOn;
    }

    // Update is called once per frame
    void Update()
    {
        BGMoveCheck();
    }

    void BGMoveCheck()
    {
        if (bgMoveOn == false)
            return;

        Vector2 currentOffSet = bgImage.material.mainTextureOffset;
        currentOffSet.x += bgMoveSpeed * Time.deltaTime;
        bgImage.material.mainTextureOffset = currentOffSet;
    }
}
