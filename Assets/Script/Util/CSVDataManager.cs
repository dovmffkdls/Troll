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

    public AniListTable aniListTable = new AniListTable();
    
    public ExpTable expTable = new ExpTable();
    public PCTable pcTable = new PCTable();
    public MapBTable mapBTable = new MapBTable();
    public BossBTable bossBTable = new BossBTable();
    public MobATable mobATable = new MobATable();
    public MobBTable mobBTable = new MobBTable();
    

    public void Load()
    {
        aniListTable.Load(CSVReader.ReadList("DB/_11_anilist"));

        expTable.Load(CSVReader.Read("DB/1_exp"));
        pcTable.Load(CSVReader.Read("DB/1_pc"));
        mapBTable.Load(CSVReader.Read("DB/2_mapb"));
        bossBTable.Load(CSVReader.Read("DB/5_bossb"));
        mobATable.Load(CSVReader.Read("DB/5_moba"));
        mobBTable.Load(CSVReader.Read("DB/5_mobb"));        
    }
}
