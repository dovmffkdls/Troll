using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTable
{
    public virtual void Load(List<Dictionary<string, object>> _datas) { }
    public virtual void Load(List<string> _datas) { }

    /// <summary>
    /// Int 값 취득
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public int GetIntValue(string value)
    {
        int resultValue = 0;

        if (!string.IsNullOrEmpty(value))
        {
            resultValue = int.Parse(value);
        }

        return resultValue;
    }

    public float GetFloatValue(string value)
    {
        float resultValue = 0;

        if (!string.IsNullOrEmpty(value))
        {
            resultValue = float.Parse(value);
        }

        return resultValue;
    }
    public bool GetBoolValue(string value)
    {
        return GetIntValue(value) == 1;
    }
}
