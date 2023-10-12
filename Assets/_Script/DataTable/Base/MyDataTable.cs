using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Reflection;
using System;
#if UNITY_EDITOR
using UnityEditor;

#endif
public class MyDataBase : ScriptableObject
{
    public virtual void CreateBinartFile(TextAsset tabFile)
    {

    }
}
public abstract class MyDataTable<T> : MyDataBase where T : class, new()
{
    [SerializeField]
    protected List<T> records=new List<T>();
    private ConfigCompare<T> configCompare;

    private void OnEnable()
    {
        configCompare = DefineCompare();
    }

    public abstract ConfigCompare<T> DefineCompare(); 
    public override void CreateBinartFile(TextAsset tabFile)
    {
  
        records.Clear();
        List<List<string>> grids = splitTabDelimited(tabFile);
        Type recordType = typeof(T);
        FieldInfo[] fieldInfos= recordType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        for (int i=1;i<grids.Count; i++)
        {
            List<string> dataline = grids[i];
            string json = "{";
            for(int x=0; x<dataline.Count; x++)
            {
                if (x > 0)
                    json += ",";
                if(fieldInfos [x].FieldType != typeof(string))
                {
                    string dataField = "0";
                    if(x<dataline.Count)
                    {
                        if (dataline[x] != string.Empty)
                            dataField = dataline[x];
                    }
                    json += "\"" + fieldInfos[x].Name + "\":" + dataField;
                }    
                else
                {
                    string dataField = string.Empty;
                    if (x < dataline.Count)
                    {
                        if (dataline[x] != string.Empty)
                            dataField = dataline[x];
                    }
                    json += "\"" + fieldInfos[x].Name + "\":\"" + dataField+"\"";
                }
            }  
            json+="}";
            Debug.Log(json);
            T r=JsonUtility.FromJson<T>(json);
            records.Add(r);
        }
        records.Sort(configCompare);
    }
    private List<List<string>> splitTabDelimited(TextAsset textAsset)
    {
        List<List<string>> grids = new List<List<string>>();
        string[] lines = textAsset.text.Split("\n");
        for ( int i = 0; i < lines.Length; i++ )
        {
            if (lines[i].Length > 0)
            {
                string[] linedata = lines[i].Split("\t");
                List<string> list_line = new List<string>();
                foreach (string s in linedata)
                {
                    string newChar = Regex.Replace(s, @"\t|\n|\r", "");
                    newChar = Regex.Replace(newChar, @"""", "\\" + "\\");
                    list_line.Add(newChar);
                }
                grids.Add(list_line);
            }
        }
        return grids;
    }
    public List<T> GetAllRecords()
    {
        return records;
    }    
    public T GetRecordByKeySearch(params object[] keys)
    {
        T key= configCompare.CreateKeySearch(keys);
        int index = records.BinarySearch(key, configCompare);
        if( (index>=0)&&(index<records.Count))
        return records[index];
        return null;

    }    
}
public class ConfigCompare<T> : IComparer<T> where T : class, new()
{
    private List<FieldInfo> keyInfos = new List<FieldInfo>();
    public ConfigCompare(params string[] keyInfoNames )
    {
        for ( int i = 0; i < keyInfoNames.Length; i++ )
        {
            FieldInfo keyInfo= typeof(T).GetField(keyInfoNames[i], BindingFlags.NonPublic | BindingFlags.Instance|BindingFlags.Public);    
            keyInfos.Add(keyInfo);
        }    
    }
    public int Compare(T x, T y)
    {

        int result = 1;
        for(int i=0;i<keyInfos.Count;i++)
        {
            object val_x=keyInfos[i].GetValue(x);
            object val_y=keyInfos[i].GetValue(y);
            result=((IComparable)val_x).CompareTo(val_y);
            if (result != 0)
                break;
        }    
        return result;

    }
    public T CreateKeySearch(params object[] values)
    {
        T key= new T();
        for (int i = 0; i <values.Length; i++)
        {
            keyInfos[i].SetValue(key, values[i]);
        }    
            return key;
    }
}    
