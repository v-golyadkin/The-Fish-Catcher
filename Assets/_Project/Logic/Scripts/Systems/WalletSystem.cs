using UnityEngine;
using PlayerPrefs = RedefineYG.PlayerPrefs;

public class WalletSystem : Singleton<WalletSystem>
{
    public int Wallet { get; private set; }

    private int _moneyGainPerCatch;

    protected override void Awake()
    {
        base.Awake();

        Wallet = PlayerPrefs.GetInt("Wallet", Wallet);
    }

    private void AddMoney(int amount)
    {
        Wallet += amount;
        PlayerPrefs.SetInt("Wallet", Wallet);
        PlayerPrefs.Save();
    }

    public void SpendMoney(int amount)
    {
        if (CanAfford(amount))
        {
            Wallet -= amount;
            PlayerPrefs.SetInt("Wallet", Wallet);
            PlayerPrefs.Save();
        }
    }

    public bool CanAfford(int price)
    {
        return Wallet >= price;
    }

    public void CalculateMoneyGainPerCatch(int amount)
    {
        _moneyGainPerCatch += amount;
        UITextUpdater.Instance.SetEndScreenMoney(_moneyGainPerCatch);
    }

    public void AddMoneyPerCatch(int catchMultiplier = 1)
    {
        AddMoney(_moneyGainPerCatch * catchMultiplier);
        _moneyGainPerCatch = 0;
    }
}
