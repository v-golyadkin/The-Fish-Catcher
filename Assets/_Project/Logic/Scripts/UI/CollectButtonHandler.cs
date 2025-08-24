using UnityEngine;

public class CollectButtonHandler : MonoBehaviour
{
    public void CollectButtonOnClick()
    {
        WalletSystem.Instance.AddMoneyPerCatch();
        ScreenSelectorSystem.Instance.ShowMainScreen();
    }

    public void CollectDoubleButtonOnClick()
    {
        WalletSystem.Instance.AddMoneyPerCatch(2);
        ScreenSelectorSystem.Instance.ShowMainScreen();
    }
}
