using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InGameController : MonoBehaviour
{
    [SerializeField] ChaObjManager chaManager;
    MapBData mapBData;
    List<MobCreateData> mobCreateDataList = new List<MobCreateData>();
    float createEnumyDelay = 0;
    [SerializeField] Slider stageSlider;

    int bossOnMaxCnt;
    int bossOnCurrentCnt;

    [SerializeField] Text stageNumText;

    // Start is called before the first frame update
    void Start()
    {
        StageSet();
    }

    void StageSet()
    {
        //캐릭터 세팅
        chaManager.ChangePlayerCha(GameDataManager.Instance.pcData);

        //스테이지 데이터 세팅
        int stageId = GameDataManager.Instance.selectStageId;
        mapBData = CSVDataManager.Instance.mapBTable.GetData(stageId);
        stageNumText.text = string.Format("{0} 스테이지" , mapBData.Id);
        bossOnMaxCnt = mapBData.BossButtonNo;
        bossOnCurrentCnt = 0;

        MobCreateDataSet();


        SliderSet();
    }

    void MobCreateDataSet()
    {
        mobCreateDataList = new List<MobCreateData>();

        if (mapBData.Moba1 != 0)
        {
            mobCreateDataList.Add(new MobCreateData(mapBData.Moba1, mapBData.Mobb1, mapBData.Number1));
        }

        if (mapBData.Moba2 != 0)
        {
            mobCreateDataList.Add(new MobCreateData(mapBData.Moba2, mapBData.Mobb2, mapBData.Number2));
        }

        if (mapBData.Moba3 != 0)
        {
            mobCreateDataList.Add(new MobCreateData(mapBData.Moba3, mapBData.Mobb3, mapBData.Number3));
        }

        if (mapBData.Moba4 != 0)
        {
            mobCreateDataList.Add(new MobCreateData(mapBData.Moba4, mapBData.Mobb4, mapBData.Number4));
        }

    }

    // Update is called once per frame
    void Update()
    {
        DelayCheck();
    }

    void DelayCheck()
    {
        createEnumyDelay -= Time.deltaTime;

        if (createEnumyDelay < 0)
        {
            createEnumyDelay = mapBData.RegenTime;
            CreateEnumyOn();
        }
    }

    void CreateEnumyOn() 
    {
        List<MobCreateData> createTargetList = GetCreateTargetList();

        if (createTargetList.Count == 0)
        {
            Debug.LogWarning("생성할 몬스터 없음");
            MobCreateDataSet();
            return;
        }

        int ranIndex = Random.Range(0, createTargetList.Count);
        int index = mobCreateDataList.FindIndex(data => data.mobAID == createTargetList[ranIndex].mobAID);
        MobCreateData mobCreateData = mobCreateDataList[index];

        MobAData mpbaData = CSVDataManager.Instance.mobATable.GetData(mobCreateData.mobAID);
        MobBData mpbbData = CSVDataManager.Instance.mobBTable.GetData(mobCreateData.mobBID);

        mobCreateData.currentNumber -= 1;

        chaManager.CreateEnumy(mpbaData, mpbbData , EnumyDieEventOn);

        //모든 몬스터를 다 생성했다면 생성 로직 초기화
        if (GetCreateTargetList().Count == 0)
        {
            MobCreateDataSet();
        }
    }

    void EnumyDieEventOn(EnumyAI enumyAI)
    {
        bossOnCurrentCnt++;
        stageSlider.value = bossOnCurrentCnt / (float)bossOnMaxCnt;
    }

    List<MobCreateData> GetCreateTargetList()
    {
        //생성할 몬스터 정보 취득
        return mobCreateDataList.Where(data => data.mobAID != 0 && data.currentNumber > 0).ToList();
    }

    void SliderSet() 
    {
        stageSlider.value = 0;
    }
}

public class MobCreateData
{
    public int mobAID = 0;
    public int mobBID = 0;
    public int maxNumber = 0;
    public int currentNumber = 0;

    public MobCreateData() { }
    public MobCreateData(int mobaID, int mobBID, int number) 
    {
        this.mobAID = mobaID;
        this.mobBID = mobBID;
        this.maxNumber = number;
        currentNumber = number;
    }
}