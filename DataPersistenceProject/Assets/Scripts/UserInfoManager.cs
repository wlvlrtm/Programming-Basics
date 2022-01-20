using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UserInfoManager : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public int score;
        public string userName;   
    }


    public static UserInfoManager Instance;
    public static string userName;
    public static string path;


    private void Awake() {
        userName = "Guest";
        path = Application.persistentDataPath + "/savefile.json";
        
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);    
        }

        Debug.Log(Application.persistentDataPath);
    }


    public void SaveName(InputField nameField) {
        userName = nameField.text;
    }


    public void SaveHighScore(int score) {
        SaveData currentData = new SaveData();
        string json;

        currentData.score = score;
        currentData.userName = userName;

        if (File.Exists(path)) {
            json = File.ReadAllText(path);
            SaveData pastData = JsonUtility.FromJson<SaveData>(json);

            if (pastData.score < currentData.score) {
                json = JsonUtility.ToJson(currentData);   
            }
            else if (pastData.score > currentData.score) {
                json = JsonUtility.ToJson(pastData);
            }
        }
        else {
            json = JsonUtility.ToJson(currentData);
        }
        
        File.WriteAllText(path, json);
    }


    public string Get_highScore() {
        string json = File.ReadAllText(path);

        return JsonUtility.FromJson<SaveData>(json).score.ToString();
    }


    public string Get_highUser() {
        string json = File.ReadAllText(path);

        return JsonUtility.FromJson<SaveData>(json).userName;
    }
}
