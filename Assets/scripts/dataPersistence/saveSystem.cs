using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class saveSystem 
{
    private static SaveData _saveData = new SaveData();

    [System.Serializable]
   public struct SaveData
    {
        public PlayerSaveData playerData;
    }

    public static string SaveFileName()
    {
        string saveFile = Application.dataPath + "/save" + ".save";
        return saveFile;
    }

    public static void Save()
    {
        HandleSaveData();
        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_saveData, true)); 
    }

    private static void HandleSaveData()
    {
        gameManager.Instance.tester.Save(ref _saveData.playerData);
    }

    public static void Load()
    {
        string saveContent = File.ReadAllText(SaveFileName());
        _saveData = JsonUtility.FromJson<SaveData>(saveContent);
        HandleLoadData();
    }

    private static void HandleLoadData()
    {
        gameManager.Instance.tester.Load(_saveData.playerData);
    }
}
