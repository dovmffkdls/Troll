using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniListTable : DataTable
{
    public Dictionary<int, List<AniListData>> dataDic = new Dictionary<int, List<AniListData>>();

    public override void Load(List<Dictionary<string, object>> _datas)
    {
        var dataEnumerator = _datas.GetEnumerator();

        List<AniListData> datas = new List<AniListData>();

        while (dataEnumerator.MoveNext())
        {
            var data = dataEnumerator.Current;

            AniListData info = new AniListData();

            info.index = GetIntValue(data["Index"].ToString());

            datas.Add(info);
        }
    }
}

[System.Serializable]
public class AniListData
{
    /// <summary> ¹øÈ£ </summary>
    public int index = 0;

}
