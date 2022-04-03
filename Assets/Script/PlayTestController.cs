using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTestController : MonoBehaviour
{
    [SerializeField] BGMoveHelper bgMoveHelper;

    [SerializeField] RectTransform chaParant;
    [SerializeField] List<Animator> playerAnimObjList = new List<Animator>();
    [SerializeField] Animator chaAnim;
    [SerializeField] Animator enumyAnim;

    private List<AniListData> playerDataList = new List<AniListData>();
    [SerializeField] PlayerSelectItem playerSelectItemPrefab;

    float enumyCreateDelay = 3;

    bool enumyOn = false;

    float attackDelay = 1;
    int attackCnt = 0;

    bool enumyAttackOn = false;
    bool enumyDieOn = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerListSet();
        chaAnim.Play("01_walk");
        bgMoveHelper.BGMoveSet(true);
        enumyAnim.gameObject.SetActive(false);
    }

    void PlayerListSet()
    {
        playerDataList = CSVDataManager.Instance.aniListTable.GetListData(0);

        foreach (var data in playerDataList)
        {
            PlayerSelectItem playerSelectItem = Instantiate(playerSelectItemPrefab, playerSelectItemPrefab.transform.parent);
            playerSelectItem.AniListDataSet(data);
            playerSelectItem.clickEvent = ChangePlayerCha;
            playerSelectItem.gameObject.SetActive(true);
        }
    }

    public void ChangePlayerCha(AniListData data)
    {
        Animator currentAnim = null;

        foreach (var playerAnimObj in playerAnimObjList)
        {
            string pcid = playerAnimObj.name.Split('_')[0];

            if (pcid == data.pcId.ToString())
            {
                currentAnim = playerAnimObj;
            }
        }

        if (currentAnim != null)
        {
            if (chaAnim != null)
            {
                Destroy(chaAnim.gameObject);
            }

            Animator newAnimator = Instantiate(currentAnim, chaParant);
            newAnimator.transform.localPosition = new Vector3(-45, -30, 0);
            newAnimator.transform.localScale = new Vector3(-1, 1, 1);

            chaAnim = newAnimator;

            chaAnim.Play("01_walk");
        }
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
        EnumyStatusCheck();
    }

    void EnumyStatusCheck() 
    {
        if (enumyAttackOn)
        {
            AttackDelayCheck();
        }
        else if (enumyOn)
        {
            EnumyMoveOn();
        }
        else 
        {
            EnumyCreateDelayCheck();
        }
    }

    void AttackDelayCheck()
    {
        if (enumyDieOn)
            return;
        
        attackDelay -= Time.deltaTime;

        if (attackDelay <= 0)
        {
            attackDelay = 1;
            StartCoroutine(AttackOn());
        }
    }

    IEnumerator AttackOn()
    {
        chaAnim.Play("10_attack");
        enumyAnim.Play("10_attack");

        attackCnt++;

        if (attackCnt >= 3)
        {
            enumyDieOn = true;
            enumyAnim.Play("50_die");
            chaAnim.Play("00_idle");
            yield return new WaitForSeconds(3);
            enumyDieOn = false;
            enumyOn = false;
            enumyAttackOn = false;
            enumyAnim.gameObject.SetActive(false);
            chaAnim.Play("01_walk");
            attackCnt = 0;
        }

        yield return null;
    }

    void EnumyMoveOn()
    {
        Vector2 currentPos = enumyAnim.transform.localPosition;

        if (currentPos.x <= -300)
        {
            currentPos.x = -300;
            enumyAttackOn = true;
            attackDelay = 0;
            AttackDelayCheck();
        }
        else
        {
            currentPos.x -= 1f;
        }

        enumyAnim.transform.localPosition = currentPos;
    }


    void EnumyCreateDelayCheck()
    {
        if (enumyOn)
            return;

        enumyCreateDelay -= Time.deltaTime;

        if (enumyCreateDelay < 0)
        {
            enumyCreateDelay = 5;
            EnumyCreateOn();
        }

    }

    void EnumyCreateOn()
    {
        enumyOn = true;
        enumyAnim.gameObject.SetActive(true);
        enumyAnim.Play("01_walk");
        Vector2 currentPos = enumyAnim.transform.localPosition;
        currentPos.x = 415;
        enumyAnim.transform.localPosition = currentPos;
    }
}
