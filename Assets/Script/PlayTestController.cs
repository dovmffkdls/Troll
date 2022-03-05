using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTestController : MonoBehaviour
{
    [SerializeField] BGMoveHelper bgMoveHelper;
    [SerializeField] Animator chaAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayToggleValueChange(bool value)
    {
        string animName = value ? "01_walk" : "00_idle";
        chaAnim.Play(animName);
        bgMoveHelper.BGMoveSet(value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
