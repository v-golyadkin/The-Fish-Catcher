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

        OfflineEarningsUpgradeLevel = PlayerPrefs.GetInt("Offline", 1);
        OfflineEarningsUpgradePrice = _upgradesPrices[OfflineEarningsUpgradeLevel - 1];
    }

    public void CalculateOfflineEarnings(DateTime lastDataTime)
    {
        totalMoneyGain = (int)((DateTime.Now - lastDataTime).TotalMinutes * OfflineEarningsUpgradeLevel + 1.0);
    }

    public void EarningsUpgrade()
    {
        OfflineEarningsUpgradeLevel++;
        OfflineEarningsUpgradePrice = _upgradesPrices[OfflineEarningsUpgradeLevel - 1];
        PlayerPrefs.SetInt("Offline", OfflineEarningsUpgradeLevel);
    }
}
