using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    private void OnApplicationPause(bool pause)
    {
        var saveLoadSystem = SaveLoadSystem.Instance;
        var earnings = OfflineEarningsUpgrade.Instance;

        if (pause)
        {
            saveLoadSystem.Save();
        }
        else
        {
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("Data")))
            {
                earnings.CalculateOfflineEarnings(saveLoadSystem.LastPlayedTime);
                ScreensManager.Instance.ChangeScreen(Screens.RETURN);
            }
        }
    }
}
