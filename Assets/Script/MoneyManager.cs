using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static Action onComed;

    [SerializeField] private Text _moneyText;

    private string SavePath;
    private static readonly SaveData saveData = new SaveData();
    SaveData data = saveData;

    private void Start()
    {
        SavePath = Application.persistentDataPath + "/stats.gameData";

        if(File.Exists(SavePath))
        {
            string fileData = File.ReadAllText(SavePath);
            SaveData data = JsonUtility.FromJson<SaveData>(fileData);
        }
        onComed = UpdateMoney;
        _moneyText.text = data.Money + " $";
    }

    private void UpdateMoney()
    {
        data.Money +=1;
        _moneyText.text = data.Money + " $";
        Save();
    }

    private void Save()
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SavePath, json);
    }
}

[System.Serializable]
public class SaveData
{
    public int Money;
}
