using Unity.VisualScripting;
using UnityEngine;
using YG;

public class CollectButtonHandler : MonoBehaviour
{
    private string rewardID = "DoubleMoney";

    private void OnEnable()
    {
        YG2.onRewardAdv += OnReward;
    }

    private void OnDisable()
    {
        YG2.onRewardAdv -= OnReward;
    }

    public void CollectButtonOnClick()
    {
        WalletSystem.Instance.AddMoneyPerCatch();
        ScreenSelectorSystem.Instance.ShowMainScreen();
    }

    public void CollectDoubleButtonOnClick()
    {
        YG2.RewardedAdvShow(rewardID);
    }

    private void OnReward(string id)
    {
        if(id == rewardID)
        {
            WalletSystem.Instance.AddMoneyPerCatch(2);
            ScreenSelectorSystem.Instance.ShowMainScreen();
        }
    }
}
