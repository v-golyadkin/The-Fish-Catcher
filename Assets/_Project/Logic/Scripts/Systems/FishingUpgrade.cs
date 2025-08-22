using UnityEngine;

public class FishingUpgrade : Singleton<FishingUpgrade>
{
    public int LengthUpgradeLevel { get; private set; }
    public int LengthUpgradePrice { get; private set; }
    public int StrengthUpgradeLevel {  get; private set; }
    public int StrengthUpgradePrice { get; private set; }

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

        LengthUpgradeLevel = -PlayerPrefs.GetInt("Length", 30);
        StrengthUpgradeLevel = PlayerPrefs.GetInt("Strength", 3);
        LengthUpgradePrice = _upgradesPrices[-LengthUpgradeLevel / 10 - 3];
        StrengthUpgradePrice = _upgradesPrices[StrengthUpgradeLevel - 3];
    }

    public void LengthUpgrade()
    {
        LengthUpgradeLevel -= 10;
        LengthUpgradePrice = _upgradesPrices[-LengthUpgradeLevel / 10 - 3];
        PlayerPrefs.SetInt("Length", LengthUpgradeLevel);
    }

    public void StrengthUpgrade()
    {
        StrengthUpgradeLevel++;
        StrengthUpgradePrice = _upgradesPrices[StrengthUpgradeLevel - 3];
        PlayerPrefs.SetInt("Strength", StrengthUpgradeLevel);
    }
}
