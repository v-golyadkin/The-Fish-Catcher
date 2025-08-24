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
            UITextUpdater.Instance.UpdateMainScreenText();
            ScreenSelectorSystem.Instance.ShowMainScreen();
        }
    }

    public void BuyStrengthUpgrade()
    {
        if (wallet.CanAfford(fishingUpgrade.StrengthUpgradePrice))
        {
            wallet.SpendMoney(fishingUpgrade.StrengthUpgradePrice);
            fishingUpgrade.StrengthUpgrade();
            UITextUpdater.Instance.UpdateMainScreenText();
            ScreenSelectorSystem.Instance.ShowMainScreen();
        }
    }

    public void BuyOfflineEarningsUpgrade()
    {
        if (wallet.CanAfford(offlineEarningsUpgrade.OfflineEarningsUpgradePrice))
        {
            wallet.SpendMoney(offlineEarningsUpgrade.OfflineEarningsUpgradePrice);
            offlineEarningsUpgrade.EarningsUpgrade();
            UITextUpdater.Instance.UpdateMainScreenText();
            ScreenSelectorSystem.Instance.ShowMainScreen();
        }
    }
}
