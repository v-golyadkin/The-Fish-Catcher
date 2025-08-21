using UnityEngine;
public class WalletManager : Singleton<WalletManager>
{
    public int Wallet { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        Wallet = PlayerPrefs.GetInt("Wallet", Wallet);
    }

    public void AddMoney(int amount)
    {
        Wallet += amount;
    }

    public void SpendMoney(int amount)
    {
        if (CanAfford(amount))
        {
            Wallet -= amount;
        }
    }

    public bool CanAfford(int price)
    {
        return Wallet >= price;
    }
}
