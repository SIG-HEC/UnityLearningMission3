using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class persistance : MonoBehaviour
{
    public static persistance Instance;
    public string playerName;
    public string bestPlayerName;
    public int highScore;
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayerName = data.playerName;
            highScore= data.highScore;
        } else
        {
            highScore = 0;
            bestPlayerName = "";
        }
            
    }
    public void SaveHighScore(int newhs)
    {
        highScore = newhs;
        bestPlayerName = playerName;
        SaveData data = new SaveData();
        data.highScore = newhs;
        data.playerName = playerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        
    }



}
