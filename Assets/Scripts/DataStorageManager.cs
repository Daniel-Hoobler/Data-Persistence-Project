using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataStorageManager : MonoBehaviour
{
    public static DataStorageManager Instance;

    public string bestScorePlayerName;
    public int bestScore;

    public string currentPlayer;
    public int currentScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadSaveData();
    }

    [System.Serializable]
    class SaveData
    {
        public string savedPlayerName;
        public int savedPlayerScore;
    }

    public void WriteSaveData()
    {
        SaveData data = new SaveData();
        data.savedPlayerName = currentPlayer;
        data.savedPlayerScore = currentScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadSaveData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScorePlayerName = data.savedPlayerName;
            bestScore = data.savedPlayerScore;
        } else
        {
            bestScorePlayerName = "Blank";
            bestScore = 0;
        }
    }
}
