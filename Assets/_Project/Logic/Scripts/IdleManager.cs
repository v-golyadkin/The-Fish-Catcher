using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class IdleManager : MonoBehaviour
{
    public int Length { get; private set; }

    public int Strength { get; private set; }

    public int OfflineEarnings { get; private set; }

    public int LengthUpgradePrice { get; private set; }

    public int StrengthUpgradePrice { get; private set; }

    public int OfflineEarningsUpdatePrice { get; private set; }

    public int wallet;

    public int totalGain;

    private int[] _upgradePrice = new int[]
    {
        120,
        151,
        197,
        250,
        324,
        414,
        537,
        687,
        892,
        1145,
        1484,
        1911,
        2479,
        3196,
        4148,
        5359,
        6954,
        9000,
        11687
    };

    public static IdleManager Instance;

    private void Awake()
    {
        if (IdleManager.Instance != null)
            UnityEngine.Object.Destroy(gameObject);
        else 
            IdleManager.Instance = this;
        //length = -30;
        Length = -PlayerPrefs.GetInt("Length", 30);
        Strength = PlayerPrefs.GetInt("Strength", 3);
        OfflineEarnings = PlayerPrefs.GetInt("Offline", 3);
        LengthUpgradePrice = _upgradePrice[-Length / 10 - 3];
        StrengthUpgradePrice = _upgradePrice[Strength - 3];
        OfflineEarningsUpdatePrice = _upgradePrice[OfflineEarnings - 3];
        wallet = PlayerPrefs.GetInt("Wallet", 0);
    }

    private void OnApplicationPause(bool paused)
    {
        if (paused)
        {
            DateTime date = DateTime.Now;
            PlayerPrefs.SetString("Data", date.ToString());
            MonoBehaviour.print(date.ToString());
        }
        else
        {
            string lastDate = PlayerPrefs.GetString("Data", string.Empty);
            if(lastDate != string.Empty)
            {
                DateTime newDate = DateTime.Parse(lastDate);
                totalGain = (int)((DateTime.Now - newDate).TotalMinutes * OfflineEarnings + 1.0);
                ScreensManager.Instance.ChangeScreen(Screens.RETURN);
            }
        }
    }

    private void OnApplicationQuit()
    {
        OnApplicationPause(true);
    }

    public void BuyLength()
    {
        Length -= 10;
        wallet -= LengthUpgradePrice;
        LengthUpgradePrice = _upgradePrice[-Length / 10 - 3];
        PlayerPrefs.SetInt("Length", -Length);
        PlayerPrefs.SetInt("Wallet", wallet);
        ScreensManager.Instance.ChangeScreen(Screens.MAIN);
    }

    public void BuyStrength()
    {
        Strength++;
        wallet -= StrengthUpgradePrice;
        StrengthUpgradePrice = _upgradePrice[Strength - 3];
        PlayerPrefs.SetInt("Strength", Strength);
        PlayerPrefs.SetInt("Wallet", wallet);
        ScreensManager.Instance.ChangeScreen(Screens.MAIN);
    }

    public void BuyOfflineEarnings()
    {
        OfflineEarnings++;
        wallet -= OfflineEarningsUpdatePrice;
        OfflineEarningsUpdatePrice = _upgradePrice[OfflineEarnings - 3];
        PlayerPrefs.SetInt("Offline", OfflineEarnings);
        PlayerPrefs.SetInt("Wallet", wallet);
        ScreensManager.Instance.ChangeScreen(Screens.MAIN);
    }

    public void CollectMoney()
    {
        wallet += totalGain;
        PlayerPrefs.SetInt("Wallet", wallet);
        ScreensManager.Instance.ChangeScreen(Screens.MAIN);
    }

    public void CollectDoubleMoney()
    {
        wallet += totalGain * 2;
        PlayerPrefs.SetInt("Wallet", wallet);
        ScreensManager.Instance.ChangeScreen(Screens.MAIN);
    }
}
