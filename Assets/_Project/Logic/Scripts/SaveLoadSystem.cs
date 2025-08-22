using System;
using UnityEngine;

public class SaveLoadSystem : Singleton<SaveLoadSystem>
{
    public DateTime LastPlayedTime { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        string lastDate = PlayerPrefs.GetString("Data", string.Empty);
        if (string.IsNullOrEmpty(lastDate))
        {
            LastPlayedTime = DateTime.Parse(lastDate);
        }
    }

    public void Save()
    {
        PlayerPrefs.SetString("Data", DateTime.Now.ToString());
    }
}
