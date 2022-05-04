using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private AccountData accountData;
    private Animator anim;
    private PCData pcData;
    private ItemBData itemBData;

    public PlayerStatus playerStatus = PlayerStatus.None;

    bool attackOn = false;
    float attackDelay = 1;

    private SpriteRenderer weaponRenderer = null;

    private float maxHp = 0;
    private float currentHp = 0;
    private float hpRecoveryDelay = 1;

    private float atkAb = 0;

    HPUI hpUI = null;

    List<int> forceAreaRate = new List<int>();

    private void Awake()
    {
        anim = GetComponent<Animator>();
        forceAreaRate = new List<int>() { 30, 30, 40 };

        AccountDataSet();
    }

    void AccountDataSet() 
    {
        accountData = CSVDataManager.Instance.accountTable.dataList[0];
    }

    public void Init(PCData pcData)
    {
        this.pcData = pcData;
        HPSet();
        WeaponRendererSet();
    }

    void HPSet()
    {
        maxHp = accountData.Hp + pcData.Hp;

        //아이템 정보가 있다면
        if (itemBData != null)
        {
            maxHp += itemBData.Hp;
        }

        currentHp = maxHp;

        HPReset();

        hpUI.ForceAreaSet(GetForceInRate());
    }

    void HPReset()
    {
        if (hpUI == null)
        {
            hpUI = Instantiate(Resources.Load<HPUI>("UI/HPUI"), transform);
            hpUI.transform.localPosition = new Vector3(0, 2.5f, 0);
            Vector3 localScale = hpUI.transform.localScale;
            localScale.x *= -1;
            hpUI.transform.localScale = localScale;
        }

        float sliderValue = currentHp == 0 ? 0 : (float)currentHp / maxHp;
        hpUI.SliderValueSet(sliderValue);
    }

    public void DamageOn(int attackValue = 5)
    {
        DamageUISet(attackValue);

        currentHp -= attackValue;

        if (currentHp <= 0)
        {
            currentHp = 0;
            StartCoroutine(DieAnimOn());
        }

        HPReset();
    }

    void DamageUISet(int attackValue)
    {
        DamageUI damageUI = Instantiate(Resources.Load<DamageUI>("UI/DamageUI"), transform);
        damageUI.DamageSet(attackValue);

        Vector3 localScale = damageUI.transform.localScale;
        localScale.x *= -1;
        damageUI.transform.localScale = localScale;
    }

    int GetForceRate()
    {
        return accountData.ForceRate + pcData.ForceRate;
    }

    int GetLethalRate()
    {
        return accountData.LethalRate;
    }

    int GetLethalAtkRate()
    {
        return accountData.LethalAtkRate + pcData.LethalAtkRate;
    }

    public float GetAtk() 
    {
        float resultAtk = accountData.Atk;

        //PC 랜덤값 적용
        resultAtk += Random.Range(pcData.Atk1, pcData.Atk2);

        //Item 랜덤값 적용
        if (itemBData != null)
        {
            resultAtk += Random.Range(itemBData.AtkMin, itemBData.AtkMax);
        }
        
        //Skill 적용

        //크리티컬 확률 계산
        if (false)
        {
            //크리티컬 데미지 
            int criRate = 1;
            resultAtk *= criRate;
        }

        //LethalAtk 데미지 적용
        resultAtk = resultAtk * GetLethalAtk();

        return resultAtk;
    }

    /// <summary>
    /// 각 Force 구간 별 영역% 얻어오기
    /// </summary>
    /// <returns></returns>
    List<float> GetForceInRate()
    {
        List<float> forceInRateList = new List<float>();

        for (int i = 0; i < forceAreaRate.Count; i++)
        {
            float rate = (100 - GetForceRate()) * (forceAreaRate[i] / 100.0f);

            if (i == 0)
            {
                rate += GetForceRate();
            }
            forceInRateList.Add(rate);
        }

        return forceInRateList;
    }

    /// <summary>
    /// 각 Force 구간 별 체력 얻어오기
    /// </summary>
    List<float> GetForceInHPValue()
    {
        List<float> forceInRateList = GetForceInRate();
        List<float> forceInHPValueList = new List<float>();

        for (int i = 0; i < forceInRateList.Count; i++)
        {
            float resultValue = maxHp * forceInRateList[i] / 100.0f;
            forceInHPValueList.Add(resultValue);
        }

        return forceInHPValueList;
    }

    float GetLethalAtk()
    {
        float resultValue = 1;

        List<float> forceInHPValueList = GetForceInHPValue();

        //3번째 구간이라면
        if (currentHp >= maxHp - forceInHPValueList[2])
        {
            resultValue = 1;
        }
        else
        {
            //LethalRate 확률 계산
            if (Random.Range( 0 , GetLethalRate()) <= GetLethalRate() -1)
            {
                //1번째 구간이라면
                if (currentHp <= forceInHPValueList[0])
                {
                    resultValue = GetLethalAtkRate() * 1.5f;
                }
                //2번째 구간이라면
                else
                {
                    resultValue = GetLethalAtkRate();
                }
            }
        }

        return resultValue;
    }

    /// <summary>
    /// 절대 공격 수치 취득
    /// </summary>
    public int GetAtkAb()
    {
        return accountData.AtkAb;
    }

    void WeaponRendererSet()
    {
        string objName = string.Empty;

        if (pcData == null)
            return;
        
        switch (pcData.MotionId)
        {
            case 1000:
                objName = "club";
                break;
            case 1100:
                objName = "swords_01";
                break;
        }

        SpriteRenderer originWeaponRenderer = null;

        foreach (var renderer in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            if (renderer.name == objName)
            {
                originWeaponRenderer = renderer;
                break;
            }
        }

        if (originWeaponRenderer != null)
        {
            weaponRenderer = Instantiate(originWeaponRenderer, originWeaponRenderer.transform.parent);
            weaponRenderer.transform.localPosition = new Vector3(3, 0, 0);
            weaponRenderer.transform.localRotation = Quaternion.Euler(0, 0, 180);

            originWeaponRenderer.gameObject.SetActive(false);
        }
    }

    public void WeaponSet(ItemBData itemBData ,Sprite weaponSprite)
    {
        this.itemBData = itemBData;

        if (weaponRenderer == null)
            return;

        weaponRenderer.sprite = weaponSprite;
        weaponRenderer.flipX = true;

        weaponRenderer.transform.localPosition = new Vector3(3, 0, 0);

        HPSet();
    }

    private void Update()
    {
        StatusCheck();
        HPRecoveryCheck();
    }

    void StatusCheck()
    {
        if (playerStatus == PlayerStatus.None)
        {
            playerStatus = PlayerStatus.Move;
        }
        else if (playerStatus == PlayerStatus.Move)
        {
            MoveCheck();
        }
        else if (playerStatus == PlayerStatus.Attack)
        {
            EnumyAttackDelayCehck();
        }
    }

    void MoveCheck()
    {
        if (AttackTargetCheck().Count > 0)
        {
            playerStatus = PlayerStatus.Attack;
            attackDelay = 0;
        }
        else 
        {
            anim.Play("01_walk");

            Vector2 currentPos = transform.localPosition;

            if (currentPos.x < -50)
            {
                currentPos.x += 0.1f;
            }
            else
            {
                currentPos.x = -50f;
            }

            transform.localPosition = currentPos;
        }
    }

    List<EnumyAI> AttackTargetCheck()
    {
        List<EnumyAI> enumyList = ChaObjManager.Instance.GetEnumyList();

        List<EnumyAI> attackTargetList = new List<EnumyAI>();

        Vector3 currentPos = transform.localPosition;

        for (int i = 0; i < enumyList.Count; i++)
        {
            float distance = Vector3.Distance(currentPos, enumyList[i].transform.localPosition);

            if (distance < 25)
            {
                attackTargetList.Add(enumyList[i]);
            }
        }

        return attackTargetList;
    }

    void EnumyAttackDelayCehck()
    {
        if (attackOn)
            return;

        attackDelay -= Time.deltaTime;

        if (attackDelay < 0 )
        {
            attackDelay = 1;
            StartCoroutine(EnumyAttackOn());
        }
    }

    IEnumerator EnumyAttackOn()
    {
        attackOn = true;

        anim.Play("10_attack");

        float delayHalf = anim.GetCurrentAnimatorClipInfo(0).Length * 0.5f;

        yield return new WaitForSeconds(delayHalf);

        List<EnumyAI> attackTargetList = AttackTargetCheck();

        if (attackTargetList.Count != 0)
        {
            foreach (var attackTarget in attackTargetList)
            {
                attackTarget.DamageOn(GetAtk());
            }
        }

        yield return new WaitForSeconds(delayHalf);

        playerStatus = PlayerStatus.Move;

        if (AttackTargetCheck().Count > 0)
        {
            playerStatus = PlayerStatus.Attack;
        }
        else
        {
            playerStatus = PlayerStatus.Move;
        }

        anim.Play("00_idle");

        attackOn = false;
    }

    void HPRecoveryCheck()
    {
        hpRecoveryDelay -= Time.deltaTime;

        if (hpRecoveryDelay < 0)
        {
            hpRecoveryDelay = 1;
            HPRecoveryOn();
        }
    }

    /// <summary>
    /// 체력 회복
    /// </summary>
    void HPRecoveryOn()
    {
        AddHp(accountData.HpRecovery);
    }

    public void AddHp(float addValue)
    {
        currentHp = Mathf.Min(currentHp + addValue, maxHp);
        HPReset();
    }

    public IEnumerator DieAnimOn()
    {
        playerStatus = PlayerStatus.Die;

        anim.Play("50_die");

        float delay = anim.GetCurrentAnimatorClipInfo(0).Length;

        yield return new WaitForSeconds(delay);
    }

}

public enum PlayerStatus 
{
    None,
    Move,
    EnumyWait,
    Attack,
    Die
} 