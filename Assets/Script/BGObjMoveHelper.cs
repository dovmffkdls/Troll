using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGObjMoveHelper : MonoBehaviour
{
    bool bgMoveOn = false;
    public float bgMoveSpeed;
    public float minXPos = 0;
    public float resetPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        BGMoveSet(true);
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
        if (GameDataManager.Instance.bgMove == false)
            return;

        Vector2 pos = transform.localPosition;
        pos.x += bgMoveSpeed * -2 * Time.deltaTime;

        if (pos.x < minXPos)
            pos.x = resetPos;
        
        transform.localPosition = pos;
    }
}
