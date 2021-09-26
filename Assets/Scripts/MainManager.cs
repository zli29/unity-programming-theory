using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public Color teamColor;

    [System.Serializable]
    private class SaveData
    {
        public Color teamColor;
    }

    private static MainManager _instance;
    public static MainManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("MainManager");
                _instance = go.AddComponent<MainManager>();
                _instance.teamColor = new Color(1f, 0, 0.84f);
            }
            return _instance;
        }
    }

    [SerializeField]
    private float missionData = 12.34f;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.teamColor = this.teamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        Debug.Log(path);
        if (!File.Exists(path))
        {
            return;
        }

        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        this.teamColor = data.teamColor;
    }
}
