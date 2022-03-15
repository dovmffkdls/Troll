using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniListTable : DataTable
{
    public Dictionary<int, List<AniListData>> dataDic = new Dictionary<int, List<AniListData>>();

    List<AniListData> aniDataList = new List<AniListData>();

    public override void Load(List<string> _datas)
    {
        foreach (var strData in _datas)
        {
            List<object> splitValue = CSVReader.ReadSplitValue(strData);

            string keyValue = splitValue[0].ToString();

            

            for (int i = 1; i < splitValue.Count; i++)
            {
                int index = i - 1;

                switch (keyValue) 
                {
                    case "pcId":
                        AniListData aniListData = new AniListData();
                        aniListData.pcId = GetIntValue(splitValue[i].ToString());
                        aniDataList.Add(aniListData);
                        break;

                    case "motionId": aniDataList[index].motionId = GetIntValue(splitValue[i].ToString());
                        break;

                    case "pcNameId": aniDataList[index].pcNameId = splitValue[i].ToString();
                        break;

                    case "00_idle" :aniDataList[index].anim_00_idle = GetBoolValue(splitValue[i].ToString());
                        break;

                    case "00_idle2":
                        aniDataList[index].anim_00_idle2 = GetBoolValue(splitValue[i].ToString());
                        break;

                    case "01_walk":
                        aniDataList[index].anim_01_walk = GetBoolValue(splitValue[i].ToString());
                        break;
                    case "02_walk_sword_on_shoulder":
                        aniDataList[index].anim_02_walk_sword_on_shoulder = GetBoolValue(splitValue[i].ToString());
                        break;
                    case "05_run":
                        aniDataList[index].anim_05_run = GetBoolValue(splitValue[i].ToString());
                        break;
                    case "06_run_sword_on_shoulder":
                        aniDataList[index].anim_06_run_sword_on_shoulder = GetBoolValue(splitValue[i].ToString());
                        break;
                    case "09_jump":
                        aniDataList[index].anim_09_jump = GetBoolValue(splitValue[i].ToString());
                        break;
                    case "10_attack":
                        aniDataList[index].anim_10_attack = GetBoolValue(splitValue[i].ToString());
                        break;
                    case "11_attack_walking":
                        aniDataList[index].anim_11_attack_walking = GetBoolValue(splitValue[i].ToString());
                        break;
                    case "12_attack_walking_sword_on_shoulder":
                        aniDataList[index].anim_12_attack_walking_sword_on_shoulder = GetBoolValue(splitValue[i].ToString());
                        break;


                }
            }
        }
    }
}

[System.Serializable]
public class AniListData
{
    /// <summary> ¹øÈ£ </summary>
    public int pcId = 0;

    public int motionId = 0;

    public string pcNameId = string.Empty;

    public bool anim_00_idle = false;
    public bool anim_00_idle2 = false;
    public bool anim_01_walk = false;
    public bool anim_02_walk_sword_on_shoulder = false;
    public bool anim_05_run = false;
    public bool anim_06_run_sword_on_shoulder = false;
    public bool anim_09_jump = false;
    public bool anim_10_attack = false;
    public bool anim_11_attack_walking = false;
    public bool anim_12_attack_walking_sword_on_shoulder = false;
    public bool anim_15_attack_running = false;
    public bool anim_16_attack_running_sword_on_shoulder = false;
    public bool anim_20_stab = false;
    public bool anim_21_throw = false;
    public bool anim_22_smash = false;
    public bool anim_23_attack_uppercut = false;
    public bool anim_24_attack_double = false;
    public bool anim_25_roar = false;
    public bool anim_26_slam = false;

    public bool anim_30_fireball = false;
    public bool anim_31_casting_start = false;
    public bool anim_32_casting_continue = false;
    public bool anim_33_rebirth = false;
    public bool anim_34_shot = false;
    public bool anim_40_defend = false;
    public bool anim_41_hurt = false;
    public bool anim_42_confused = false;
    public bool anim_43_defend_sheild = false;
    public bool anim_44_play_dead = false;
    public bool anim_50_die = false;

}
