using System;
using UnityEngine;

public class OfflineEarningsUpgrade : Singleton<OfflineEarningsUpgrade>
{
    public int OfflineEarningsUpgradeLevel {  get; private set; }
    public int OfflineEarningsUpgradePrice { get; private set; }

    public int totalMoneyGain { get; private set; }

    private int[] _upgradesPrices = new int[]    
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

    protected override void Awake()
    {
        base.Awake();

        OfflineEarningsUpgradeLevel = PlayerPrefs.GetInt("Offline", 0);
        OfflineEarningsUpgradePrice = _upgradesPrices[OfflineEarningsUpgradeLevel];
    }

    public int CalculateOfflineEarnings(string lastDataTime, float minOfflineDurationInSeconds = 0f, float maxOfflineDurationInSeconds = 0f)
    {
        DateTime lastData = DateTime.Parse(lastDataTime);
        TimeSpan offlineTime = DateTime.Now - lastData;

        if(offlineTime.TotalSeconds < minOfflineDurationInSeconds)
        {
            return 0;
        }

        float effectiveMinutes = Mathf.Min((float)offlineTime.TotalMinutes, maxOfflineDurationInSeconds / 60f);
        totalMoneyGain = (int)((effectiveMinutes * OfflineEarningsUpgradeLevel));
        return totalMoneyGain;
    }

    public void EarningsUpgrade()
    {
        OfflineEarningsUpgradeLevel++;
        OfflineEarningsUpgradePrice = _upgradesPrices[OfflineEarningsUpgradeLevel];
        PlayerPrefs.SetInt("Offline", OfflineEarningsUpgradeLevel);
    }
}
