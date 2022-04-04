using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumyAI : MonoBehaviour
{
    private Animator anim;
    private AniListData animData;

    public EnumyStatus enumyStatus = EnumyStatus.None;

    bool attackOn = false;
    float attackDelay = 2;

    int hp = 10;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Init(AniListData animData)
    {
        this.animData = animData;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StatusCheck();
    }
    void StatusCheck()
    {
        if (enumyStatus == EnumyStatus.None)
        {
            enumyStatus = EnumyStatus.Move;
            anim.Play("01_walk");
        }
        else if (enumyStatus == EnumyStatus.Move)
        {
            MoveCheck();
        }
        else if (enumyStatus == EnumyStatus.PlayerWait)
        {
            PlayerCheck();
        }
        else if (enumyStatus == EnumyStatus.Attack)
        {
            PlayerAttackDelayCehck();
        }
    }

    void MoveCheck()
    {
        Vector2 currentPos = transform.localPosition;

        if (currentPos.x > -30)
        {
            currentPos.x -= 0.1f;
        }
        else
        {
            currentPos.x = -30f;
            enumyStatus = EnumyStatus.PlayerWait;
        }

        transform.localPosition = currentPos;
    }

    void PlayerCheck()
    {
        Player player = ChaObjManager.Instance.GetPlayer();

        Vector3 currentPos = transform.localPosition;

        float distance = Vector3.Distance(currentPos, player.transform.localPosition);

        if (distance <= 20)
        {
            enumyStatus = EnumyStatus.Attack;
            attackDelay = 0;
        }
    }

    void PlayerAttackDelayCehck()
    {
        if (attackOn)
            return;

        attackDelay -= Time.deltaTime;

        if (attackDelay < 0)
        {
            attackDelay = 2;
            StartCoroutine(PlayerAttackOn());
        }
    }

    IEnumerator PlayerAttackOn()
    {
        attackOn = true;

        anim.Play("10_attack");

        float delay = anim.GetCurrentAnimatorClipInfo(0).Length;

        yield return new WaitForSeconds(delay);

        anim.Play("00_idle");

        attackOn = false;
    }

    public void DamageOn(int attackValue = 5)
    {
        hp -= attackValue;

        if (hp <= 0)
        {
            hp = 0;
            enumyStatus = EnumyStatus.Die;
            StartCoroutine(DieAnimOn());
        }
    }

    public IEnumerator DieAnimOn()
    {
        anim.Play("50_die");

        float delay = anim.GetCurrentAnimatorClipInfo(0).Length;

        yield return new WaitForSeconds(delay);

        ChaObjManager.Instance.RemoveEnumy(this);
    }
}

public enum EnumyStatus
{
    None,
    Move,
    PlayerWait,
    Attack,
    Die
}
