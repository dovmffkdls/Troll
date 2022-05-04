using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DamageUI : MonoBehaviour
{
    [SerializeField] Text text;

    public void DamageSet(float value)
    {
        text.text = ((int)value).ToString();

        transform.localScale = Vector3.one * 0.1f;
        transform.localPosition = new Vector3(-1, 20, 0);

        StartCoroutine(AnimOn());
    }

    IEnumerator AnimOn()
    {
        yield return new WaitForEndOfFrame();

        text.transform.DOLocalMoveY(25, 2);
        text.DOFade(0, 1).SetDelay(0.5f);
        yield return new WaitForSeconds(1);
    }
}
