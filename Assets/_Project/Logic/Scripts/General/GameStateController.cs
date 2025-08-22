public class GameStateController : Singleton<GameStateController>
{
    public int GameCount { get; private set; }
    public void IncrementGameCount() => GameCount++;

    public void HandleGameComplition(int totalGain)
    {
        UITextUpdater.Instance.SetEndScreenMoney(totalGain);
        WalletSystem.Instance.CalculateMoneyGainPerCatch(totalGain);
        ScreenSelectorSystem.Instance.ShowEndScreen();
    }

    public void HandleReturnFromOffline(int totalGain)
    {
        UITextUpdater.Instance.SetReturnScreenMoney(totalGain);
        WalletSystem.Instance.CalculateMoneyGainPerCatch(totalGain);
        ScreenSelectorSystem.Instance.ShowReturnScreen();
    }
}
