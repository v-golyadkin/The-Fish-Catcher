using System;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] private float minPauseDurationInSeconds = 60f;
    [SerializeField] private float maxPauseDurationInSeconds = 3600f;
    [SerializeField] private bool debugMod = true;

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SavePauseTime();
        }
        else 
        {
            HandleReturnFromPause();
        }
    }

    private void SavePauseTime()
    {
        DateTime date = DateTime.Now;
        PlayerPrefs.SetString("Date", date.ToString());

        if (debugMod)
        {
            Debug.Log($"Игра поставлена на паузу: {date}");
        }
    }

    private void HandleReturnFromPause()
    {
        var earnings = OfflineEarningsUpgrade.Instance;

        string lastData = PlayerPrefs.GetString("Date", string.Empty);
        if (string.IsNullOrEmpty(lastData))
        {
            return;
        }

        if (lastData != string.Empty)
        {
            int offlineEarnings = earnings.CalculateOfflineEarnings(lastData, minPauseDurationInSeconds, maxPauseDurationInSeconds);

            if (offlineEarnings > 0)
            {
                GameStateController.Instance.HandleReturnFromOffline(offlineEarnings);
            }
        }
    }

    [ContextMenu("Test 2 Hours Offline")]
    private void Test2HoursOffline()
    {
        DateTime testDate = DateTime.Now.AddHours(-2);
        PlayerPrefs.SetString("Date", testDate.ToString());
        HandleReturnFromPause();
    }

    [ContextMenu("Test 30 Minutes Offline")]
    private void Test30MinutesOffline()
    {
        DateTime testDate = DateTime.Now.AddMinutes(-30);
        PlayerPrefs.SetString("Date", testDate.ToString());
        HandleReturnFromPause();
    }
    [ContextMenu("Test 5 Minutes Offline")]
    private void Test5MinutesOffline()
    {
        DateTime testDate = DateTime.Now.AddMinutes(-5);
        PlayerPrefs.SetString("Date", testDate.ToString());
        HandleReturnFromPause();
    }

}
