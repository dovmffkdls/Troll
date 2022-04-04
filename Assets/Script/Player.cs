﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private AniListData animData;

    public PlayerStatus playerStatus = PlayerStatus.None;

    bool attackOn = false;
    float attackDelay = 1;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Init(AniListData animData)
    {
        this.animData = animData;
    }

    private void Update()
    {
        StatusCheck();
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
                attackTarget.DamageOn();
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
}

public enum PlayerStatus 
{
    None,
    Move,
    EnumyWait,
    Attack,
    Die
} 