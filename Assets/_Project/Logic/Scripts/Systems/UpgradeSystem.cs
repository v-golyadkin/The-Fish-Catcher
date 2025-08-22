using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private WalletSystem wallet;
    [SerializeField] private FishingUpgrade fishingUpgrade;
    [SerializeField] private OfflineEarningsUpgrade offlineEarningsUpgrade;


    public void BuyLengthUpgrade()
    {
        if (wallet.CanAfford(fishingUpgrade.LengthUpgradePrice))
        {
            wallet.SpendMoney(fishingUpgrade.LengthUpgradePrice);
            fishingUpgrade.LengthUpgrade();
            ScreensManager.Instance.ChangeScreen(Screens.MAIN);
        }
    }

    public void BuyStrengthUpgrade()
    {
        if (wallet.CanAfford(fishingUpgrade.StrengthUpgradePrice))
        {
            wallet.SpendMoney(fishingUpgrade.StrengthUpgradePrice);
            fishingUpgrade.StrengthUpgrade();
            ScreensManager.Instance.ChangeScreen(Screens.MAIN);
        }
    }

    public void BuyOfflineEarningsUpgrade()
    {
        if (wallet.CanAfford(offlineEarningsUpgrade.OfflineEarningsUpgradePrice))
        {
            wallet.SpendMoney(offlineEarningsUpgrade.OfflineEarningsUpgradePrice);
            offlineEarningsUpgrade.EarningsUpgrade();
            ScreensManager.Instance.ChangeScreen(Screens.MAIN);
        }
    }
}
