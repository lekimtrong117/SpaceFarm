using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DataEventTrigger : UnityEvent<object>
{

}
public static class DataTrigger
{
    private static Dictionary<string, DataEventTrigger> dicOnValueChange = new Dictionary<string, DataEventTrigger>();
    public static void RegisterValueChange(string path, UnityAction<object> delegateDataChange)
    {
        if (dicOnValueChange.ContainsKey(path))
        {
            dicOnValueChange[path].AddListener(delegateDataChange);
        }
        else
        {
            dicOnValueChange.Add(path, new DataEventTrigger());
            dicOnValueChange[path].AddListener(delegateDataChange);
        }
    }
    public static void UnRegisterValueChange(string path, UnityAction<object> delegateDataChange)
    {
        if (dicOnValueChange.ContainsKey(path))
        {
            dicOnValueChange[path].RemoveListener(delegateDataChange);
        }
    }
    public static void TriggerEventData(this object data, string path)
    {
        if (dicOnValueChange.ContainsKey(path))
        {
            dicOnValueChange[path].Invoke(data);
        }
    }
}
public class DataLocalModel : MonoBehaviour
{
    //CRU create read update
    private UseData userdata;
    public void CreateData(Action callback)
    {
        userdata = LoadData();
        if (userdata != null)
        {
            callback();
        }
        else
        {
            //create
            userdata = new UseData();
            userdata.highestscore = 0;
            SaveData();
            callback();
        }
    }
    private List<string> GetPath(string path)
    {
        string[] s = path.Split("/");
        List<string> ls = new List<string>();
        ls.AddRange(s);
        return ls;
    }
    public T Read<T>(string path)
    {
        object data = null;
        ReadDataByPath(GetPath(path), userdata, out data);
        return (T)data;
    }
    public T ReadKey<T>(string path, string key)
    {
        object data = null;
        ReadDataByPath(GetPath(path), userdata, out data);
        Dictionary<string, T> dic_Data = (Dictionary<string, T>)data;
        T outData;
        dic_Data.TryGetValue(key, out outData);
        return outData;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="paths">path of data</param>
    /// <param name="data"> root data</param>
    /// <param name="dataOut"> read data</param>
    private void ReadDataByPath(List<string> paths, object data, out object dataOut)
    {
        string p = paths[0];
        Type t = data.GetType();
        FieldInfo field = t.GetField(p);
        if (paths.Count == 1)
        {
            dataOut = field.GetValue(data);
        }
        else
        {
            paths.RemoveAt(0);
            ReadDataByPath(paths, field.GetValue(data), out dataOut);
        }

    }
    public void UpdateData(string path, object dataNew, Action callback)
    {
        List<object> ls_datachange = new List<object>();
        List<string> paths = GetPath(path);
        UpdateDataByPath(GetPath(path), userdata, dataNew, ref ls_datachange, callback);
        SaveData();
        string e_path = string.Empty;
        paths.Clear();
        paths = GetPath(path);
        for (int i = 0; i < paths.Count; i++)
        {
            if (i == 0)
            {
                e_path = paths[0];
            }
            else
            {
                e_path = e_path + "/" + paths[i];
            }
            ls_datachange[i].TriggerEventData(e_path);
        }
    }

    private void UpdateDataByPath(List<string> paths, object data, object dataNew, ref List<object> datas_change, Action callback = null)
    {
        string p = paths[0];
        Type t = data.GetType();
        FieldInfo field = t.GetField(p);
        if (paths.Count == 1)
        {
            datas_change.Add(dataNew);
            field.SetValue(data, dataNew);
            callback?.Invoke();
        }
        else
        {
            object dataAdd = field.GetValue(data);
            datas_change.Add(dataAdd);
            paths.RemoveAt(0);
            UpdateDataByPath(paths, dataAdd, dataNew, ref datas_change, callback);
        }

    }
    public void UpdateDataKey<T>(string path, string key, T dataNew, Action callback)
    {
        List<object> ls_datachange = new List<object>();
        List<string> paths = GetPath(path);
        UpdateDataKeyByPath<T>(GetPath(path), userdata, key, dataNew,ref ls_datachange, callback);
        SaveData();
        string e_path = string.Empty;
        paths.Clear();
        paths = GetPath(path);
        for (int i = 0; i < paths.Count; i++)
        {
            if (i == 0)
            {
                e_path = paths[0];
            }
            else
            {
                e_path = e_path + "/" + paths[i];
            }
            ls_datachange[i].TriggerEventData(e_path);
        }
        dataNew.TriggerEventData(e_path+"/"+key);
    }
    private void UpdateDataKeyByPath<T>(List<string> paths, object data, string key, T dataNew, ref List<object> datas_change, Action callback = null)
    {
        string p = paths[0];
        Type t = data.GetType();
        FieldInfo field = t.GetField(p);
        if (paths.Count == 1)
        {
            object dic = field.GetValue(data);
            Dictionary<string, T> dic_new = (Dictionary<string, T>)dic;
            dic_new[key] = dataNew;
            datas_change.Add(dic_new);
            field.SetValue(data, dic_new);
            callback?.Invoke();
        }
        else
        {
            object dataAdd = field.GetValue(data);
            datas_change.Add(dataAdd);
            paths.RemoveAt(0);
            UpdateDataKeyByPath<T>(paths, dataAdd, key, dataNew, ref datas_change, callback);
        }

    }
    private UseData LoadData()
    {
        if (PlayerPrefs.HasKey("DATA"))
        {
            string dataJson = PlayerPrefs.GetString("DATA");
            return JsonConvert.DeserializeObject<UseData>(dataJson);
        }
        else
            return null;
    }
    private void SaveData()
    {
        string dataJson = JsonConvert.SerializeObject(userdata);
        PlayerPrefs.SetString("DATA", dataJson);
    }
}