using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Reflection;

/// <summary>
/// CSV 리더
/// </summary>
public class CSVReader
{
    private const string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    private const string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    private const char TRIM_CHARS = '\"';

    public static List<Dictionary<string, object>> Read(string file)
    {
        var list = new List<Dictionary<string, object>>();
        TextAsset data = Resources.Load(file) as TextAsset;
       
        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1)
            return list;

        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++)
        {

            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "")
                continue;

            var entry = new Dictionary<string, object>();
            for (var j = 0; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\n", "\n");
                object finalvalue = value;
                int n;
                float f;
                if (int.TryParse(value, out n))
                {
                    finalvalue = n;
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                }
                entry[header[j]] = finalvalue;
            }
            list.Add(entry);
        }
        return list;
    }

    public static List<string> ReadList(string file)
    {
        var list = new List<string>();
        TextAsset data = Resources.Load(file) as TextAsset;

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1)
            return list;

        foreach (var str in lines)
        {
            list.Add(str);
        }

        //Debug.LogWarning(lines.Length);

        //foreach (var item in lines)
        //{
        //    Debug.LogWarning(item);
        //}

        //var header = Regex.Split(lines[0], SPLIT_RE);
        //for (var i = 1; i < lines.Length; i++)
        //{

        //    var values = Regex.Split(lines[i], SPLIT_RE);
        //    if (values.Length == 0 || values[0] == "")
        //        continue;

        //    object entry = null;
        //    for (var j = 0; j < header.Length && j < values.Length; j++)
        //    {
        //        string value = values[j];
        //        value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\n", "\n");
        //        object finalvalue = value;
        //        int n;
        //        float f;
        //        if (int.TryParse(value, out n))
        //        {
        //            finalvalue = n;
        //        }
        //        else if (float.TryParse(value, out f))
        //        {
        //            finalvalue = f;
        //        }
        //        entry = finalvalue;
        //    }
        //    list.Add(entry);
        //}

        //Debug.LogWarning(list.Count);

        //foreach (var item in list)
        //{
        //    Debug.LogWarning(item);
        //}

        return list;
    }

    public static List<object> ReadSplitValue(string lineStr)
    {
        List<object> list = new List<object>();

        var lineSplit = Regex.Split(lineStr, SPLIT_RE);
        object entry = null;
        for (var i = 0; i < lineSplit.Length; i++)
        {
            string value = lineSplit[i];
            value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\n", "\n");
            object finalvalue = value;
            int n;
            float f;
            if (int.TryParse(value, out n))
            {
                finalvalue = n;
            }
            else if (float.TryParse(value, out f))
            {
                finalvalue = f;
            }
            entry = finalvalue;

            list.Add(entry);
        }

        return list;
    }

    public static List<T> ReadAutoData<T>(string file) where T : new()
    {
        var dataList = new List<T>();

        TextAsset data = Resources.Load(file) as TextAsset;

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1)
            return dataList;

        var header = Regex.Split(lines[0], SPLIT_RE);

        for (int i = 0; i < header.Length; i++)
        {
            header[i] = header[i].Replace("\"", "");
        }

        for (var i = 3; i < lines.Length; i++)
        {
            T classData = new T();

            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "")
                continue;

            DataFieldType dataFieldType = DataFieldType.String;

            var entry = new Dictionary<string, object>();
            for (var j = 0; j < header.Length && j < values.Length; j++)
            {
                dataFieldType = DataFieldType.String;

                string value = values[j];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\n", "\n");
                object finalvalue = value;
                int n;
                float f;
                if (int.TryParse(value, out n))
                {
                    finalvalue = n;
                    dataFieldType = DataFieldType.Int;
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                    dataFieldType = DataFieldType.Float;
                }

                if (classData.GetType().GetField(header[j]) == null)
                {
                    Debug.LogWarning(" header null = " + header[j]);
                }
                else
                {
                    FieldInfo fi = classData.GetType().GetField(header[j]);

                    if (dataFieldType == DataFieldType.String && (string)finalvalue == "" )
                    {
                        if (fi.FieldType != typeof(string)) 
                        {
                            finalvalue = 0;
                        }
                    }

                    //Debug.LogWarning(header[j]);
                    classData.GetType().GetField(header[j]).SetValue(classData, finalvalue);
                }
            }

            dataList.Add(classData);
        }
        return dataList;
    }
    public enum DataFieldType
    {
        Int,
        Float,
        String,
    }
}
