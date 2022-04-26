using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpeedTable : DataTable
{
    public List<PlaySpeedData> dataList = new List<PlaySpeedData>();

    public void Load(List<PlaySpeedData> dataList)
    {
        this.dataList = dataList;
    }
}

[System.Serializable]
public class PlaySpeedData
{
    public int MotionId = 0;
    public int _00_idle = 0;
    public int _01_walk = 0;
    public int _02_walk_sword_on_shoulder = 0;
    public int _04_idle2 = 0;
    public int _05_run = 0;
    public int _06_run_sword_on_shoulder = 0;
    public int _09_jump = 0;
    public int _10_attack = 0;
    public int _11_attack_walking = 0;
    public int _12_attack_walking_sword_on_shoulder = 0;
    public int _15_attack_running = 0;
    public int _16_attack_running_sword_on_shoulder = 0;
    public int _20_stab = 0;

    public int _21_throw = 0;
    public int _22_smash = 0;
    public int _23_attack_uppercut = 0;
    public int _24_attack_double = 0;
    public int _25_roar = 0;
    public int _26_slam = 0;
    public int _30_fireball = 0;
    public int _31_casting_start = 0;
    public int _32_casting_continue = 0;
    public int _33_rebirth = 0;
    public int _34_shot = 0;
    public int _40_defend = 0;

    public int _41_hurt = 0;
    public int _42_confused = 0;
    public int _43_defend_sheild = 0;
    public int _44_play_dead = 0;
    public int _50_die = 0;
}