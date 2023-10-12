using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public static class MyDataTableMaker
{
    [MenuItem("Assets/TRONG/Create Binary File for Delimited (txt)",false,1)]
   private static void CreateBinaryFile()
    {
        foreach(UnityEngine.Object obj in Selection.objects)
        {
            TextAsset textFile=(TextAsset)obj;
            string tableName = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(textFile));
            ScriptableObject scriptableObject= ScriptableObject.CreateInstance(tableName);
            if (scriptableObject == null)
                return;
            AssetDatabase.CreateAsset(scriptableObject, "Assets/Resources/DataTable/"+tableName+".asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            MyDataBase myDataBase = (MyDataBase)scriptableObject;
            myDataBase.CreateBinartFile(textFile);
            EditorUtility.SetDirty(myDataBase);
        }    
    }
}
