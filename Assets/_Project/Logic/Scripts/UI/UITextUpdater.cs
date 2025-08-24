using TMPro;
using UnityEngine;

public class UITextUpdater : Singleton<UITextUpdater>
{
    [SerializeField] private TMP_Text gameScreenMoney;
    [SerializeField] private TMP_Text lengthPriceText;
    [SerializeField] private TMP_Text lengthValueText;
    [SerializeField] private TMP_Text strengthPriceText;
    [SerializeField] private TMP_Text strengthValueText;
    [SerializeField] private TMP_Text offlinePriceText;
    [SerializeField] private TMP_Text offlineValueText;
    [SerializeField] private TMP_Text endScreenMoney;
    [SerializeField] private TMP_Text returnScreenMoney;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        UpdateMainScreenText();
    }

    public void SetEndScreenMoney(int amount)
    {
        endScreenMoney.text = $"${amount}";
    }

    public void SetReturnScreenMoney(int amount)
    {
        returnScreenMoney.text = $"${amount} gained while waiting";
    }

    public void UpdateMainScreenText()
    {
        var wallet = WalletSystem.Instance;
        var fishingUpgrade = FishingUpgrade.Instance;
        var earningsUpdate = OfflineEarningsUpgrade.Instance;

        gameScreenMoney.text = $"${wallet.Wallet}";
        lengthPriceText.text = $"${fishingUpgrade.LengthUpgradePrice}";
        lengthValueText.text = $"{-fishingUpgrade.LengthUpgradeLevel} m";
        strengthPriceText.text = $"${fishingUpgrade.StrengthUpgradePrice}";
        strengthValueText.text = $"{fishingUpgrade.StrengthUpgradeLevel} fishes";
        offlinePriceText.text = $"${earningsUpdate.OfflineEarningsUpgradePrice}";
        offlineValueText.text = $"${earningsUpdate.OfflineEarningsUpgradeLevel} /min";
    }
}
