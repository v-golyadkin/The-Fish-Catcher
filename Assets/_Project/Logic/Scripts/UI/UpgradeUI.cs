using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private UpgradeSystem upgradeSystem;

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
}
