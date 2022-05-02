using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumyAI : MonoBehaviour
{
    private Animator anim;
    private MobBData mobBData;

    public EnumyStatus enumyStatus = EnumyStatus.None;

    bool attackOn = false;
    float attackDelay = 2;

    int maxHp = 10;
    int currentHp = 10;
    HPUI hpUI = null;

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

        if (currentPos.x > -35)
        {
            currentPos.x -= 0.1f;
        }
        else
        {
            currentPos.x = -35f;
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


    public void DamageOn(int attackValue = 5)
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

    void DamageUISet(int attackValue)
    {
        DamageUI damageUI = Instantiate(Resources.Load<DamageUI>("UI/DamageUI"), transform);
        damageUI.DamageSet(attackValue);
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
