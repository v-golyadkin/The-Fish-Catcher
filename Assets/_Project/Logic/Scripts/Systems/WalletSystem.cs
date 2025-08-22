using UnityEngine;
public class WalletSystem : Singleton<WalletSystem>
{
    public int Wallet { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        Wallet = PlayerPrefs.GetInt("Wallet", Wallet);
        AddMoney(500);
    }

    public void AddMoney(int amount)
    {
        Wallet += amount;
        PlayerPrefs.SetInt("Wallet", Wallet);
    }

    public void SpendMoney(int amount)
    {
        if (CanAfford(amount))
        {
            Wallet -= amount;
            PlayerPrefs.SetInt("Wallet", Wallet);
        }
    }

    public bool CanAfford(int price)
    {
        return Wallet >= price;
    }
}
