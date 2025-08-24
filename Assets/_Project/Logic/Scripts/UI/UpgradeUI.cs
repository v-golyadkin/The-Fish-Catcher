using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private UpgradeSystem upgradeSystem;

    [SerializeField] private Button lengthUpgradeButton;
    [SerializeField] private Button strengthUpgradeButton;
    [SerializeField] private Button offlineUpgradeButton;

    private void Update()
    {
        UpdateButtonsInteractability();
    }

    public void LengthUpgradeOnClick()
    {
        upgradeSystem.BuyLengthUpgrade();
    }

    public void StrengthUpgradeOnClick()
    {
        upgradeSystem.BuyStrengthUpgrade();
    }

    public void OfflineEarningsUpgradeOnClick()
    {
        upgradeSystem.BuyOfflineEarningsUpgrade();
    }

    private void UpdateButtonsInteractability()
    {
        lengthUpgradeButton.interactable = WalletSystem.Instance.CanAfford(FishingUpgrade.Instance.LengthUpgradePrice);
        strengthUpgradeButton.interactable = WalletSystem.Instance.CanAfford(FishingUpgrade.Instance.StrengthUpgradePrice);
        offlineUpgradeButton.interactable = WalletSystem.Instance.CanAfford(OfflineEarningsUpgrade.Instance.OfflineEarningsUpgradePrice);
    }
}
