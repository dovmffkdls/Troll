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

    AniListTable aniListTable = new AniListTable();

    public void Load()
    {
        aniListTable.Load(CSVReader.Read("DB/_11_anilist"));
    }
}
