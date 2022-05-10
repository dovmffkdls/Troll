using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class EnumyAI : MonoBehaviour
{
    private Animator anim;
    public MobBData mobBData;

    public EnumyStatus enumyStatus = EnumyStatus.None;

    bool attackOn = false;
    float attackDelay = 0;

    float maxHp = 10;
    float currentHp = 10;
    HPUI hpUI = null;

    public UnityAction<EnumyAI> dieEventOn;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Init(MobBData mobBData)
    {
        this.mobBData = mobBData;
        maxHp = this.mobBData.Hp;
        currentHp = maxHp;

        hpUI =Instantiate(Resources.Load<HPUI>("UI/HPUI") , transform);

        Transform shadowImage = Instantiate(Resources.Load<Transform>("UI/ShadowImage"), transform);
        

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
            enumyStatus = EnumyStatus.PlayerWait;
            anim.Play("01_walk");

            Vector2 targetPos = transform.localPosition;
            targetPos.x = 0;

            float distance = Vector2.Distance(targetPos, transform.localPosition);

            float duration = distance / 22;

            transform
                .DOLocalMoveX(0, duration)
                .SetEase(Ease.Linear);
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

    void PlayerCheck()
    {
        Player player = ChaObjManager.Instance.GetPlayer();

        Vector3 currentPos = transform.localPosition;

        float distance = Vector3.Distance(currentPos, player.transform.localPosition);

        if (distance <= 25)
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

        if (ChaObjManager.Instance.GetPlayer().playerStatus != PlayerStatus.Die)
        {
            anim.Play("10_attack");

            float delay = anim.GetCurrentAnimatorClipInfo(0).Length;

            yield return new WaitForSeconds(delay);

            ChaObjManager.Instance.GetPlayer().DamageOn(GetAtk());
        }

        anim.Play("00_idle");

        attackOn = false;
    }

    int GetAtk()
    {
        int damage = Random.Range(mobBData.AtkMin, mobBData.AtkMax);

        return damage;
    }


    public void DamageOn(float attackValue = 5)
    {
        DamageUISet(attackValue);

        currentHp -= attackValue;

        if (currentHp <= 0)
        {
            currentHp = 0;
            enumyStatus = EnumyStatus.Die;
            StartCoroutine(DieAnimOn());
        }

        float sliderValue = currentHp == 0 ? 0 : (float)currentHp / maxHp;
        hpUI.SliderValueSet(sliderValue);
    }

    void DamageUISet(float attackValue)
    {
        DamageUI damageUI = Instantiate(Resources.Load<DamageUI>("UI/DamageUI"), transform);
        damageUI.DamageSet(attackValue);
    }

    public IEnumerator DieAnimOn()
    {
        anim.Play("50_die");

        float delay = anim.GetCurrentAnimatorClipInfo(0).Length;

        yield return new WaitForSeconds(delay);

        if (dieEventOn != null)
        {
            dieEventOn(this);
        }

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
