using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVDataManager
{
    private static CSVDataManager _instance;
    public static CSVDataManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new CSVDataManager();

            return _instance;
        }
    }

    private CSVDataManager() 
    {
        Load();
    }

    public AccountTable accountTable = new AccountTable();
    public ExpTable expTable = new ExpTable();
    public PCTable pcTable = new PCTable();
    public PCUpTable pcUpTable = new PCUpTable();
    public DungeonbTable dungeonbTable = new DungeonbTable();
    public MapBTable mapBTable = new MapBTable();
    public ItemEchantExcessTable itemEchantExcessTable = new ItemEchantExcessTable();
    public ItemOptionTable itemOptionTable = new ItemOptionTable();
    public ItemOptionGachaTable itemOptionGachaTable = new ItemOptionGachaTable();
    public ItemATable itemATable = new ItemATable();
    public ItemBTable itemBTable = new ItemBTable();
    public SkillATable skillATable = new SkillATable();
    public BossBTable bossBTable = new BossBTable();
    public MobATable mobATable = new MobATable();
    public MobBTable mobBTable = new MobBTable();
    public PlaySpeedTable playSpeedTable = new PlaySpeedTable();
    public PCStatUpTable pcStatUpTable = new PCStatUpTable();
    public SantuaryTable santuaryTable = new SantuaryTable();

    public AniListTable aniListTable = new AniListTable();
    
    
    public void Load()
    {
        accountTable.Load(CSVReader.ReadAutoData<AccountData>("DB/1_account"));
        expTable.Load(CSVReader.ReadAutoData<ExpData>("DB/1_exp"));
        pcTable.Load(CSVReader.ReadAutoData<PCData>("DB/1_pc"));
        pcUpTable.Load(CSVReader.ReadAutoData<PCUpData>("DB/1_pc_up"));
        dungeonbTable.Load(CSVReader.ReadAutoData<DungeonbData>("DB/2_dungeonb"));
        mapBTable.Load(CSVReader.ReadAutoData<MapBData>("DB/2_mapb"));
        itemEchantExcessTable.Load(CSVReader.ReadAutoData<ItemEchantExcessData>("DB/3_item_echant_excess"));
        itemOptionTable.Load(CSVReader.ReadAutoData<ItemOptionData>("DB/3_item_option"));
        itemOptionGachaTable.Load(CSVReader.ReadAutoData<ItemOptionGachaData>("DB/3_item_option_gacha"));
        itemATable.Load(CSVReader.ReadAutoData<ItemAData>("DB/3_itema"));
        itemBTable.Load(CSVReader.ReadAutoData<ItemBData>("DB/3_itemb"));
        skillATable.Load(CSVReader.ReadAutoData<SkillAData>("DB/4_skilla"));
        bossBTable.Load(CSVReader.ReadAutoData<BossBData>("DB/5_bossb"));
        mobATable.Load(CSVReader.ReadAutoData<MobAData>("DB/5_moba"));
        mobBTable.Load(CSVReader.ReadAutoData<MobBData>("DB/5_mobb"));
        playSpeedTable.Load(CSVReader.ReadAutoData<PlaySpeedData>("DB/5_play_speed"));
        pcStatUpTable.Load(CSVReader.ReadAutoData<PCStatUpData>("DB/11_pc_stat_up"));
        santuaryTable.Load(CSVReader.ReadAutoData<SantuaryData>("DB/1414_santuary"));

        aniListTable.Load(CSVReader.ReadList("DB/_11_anilist"));
    }
}
