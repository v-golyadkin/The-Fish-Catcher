using UnityEngine;

public class ScreenSelectorSystem : Singleton<ScreenSelectorSystem>
{
    private GameObject _currentScreen;

    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject returnScreen;
    [SerializeField] private GameObject gameScreen;

    public void ShowMainScreen() => ChangeScreen(Screen.MAIN);
    public void ShowGameScreen() => ChangeScreen(Screen.GAME);
    public void ShowReturnScreen() => ChangeScreen(Screen.RETURN);
    public void ShowEndScreen()
    {
        ChangeScreen(Screen.END);
    }

    private void ChangeScreen(Screen screen)
    {
        _currentScreen?.SetActive(false);

        switch (screen)
        {
            case Screen.MAIN:
                _currentScreen = mainScreen;
                break;
            case Screen.END:
                _currentScreen = endScreen;
                break;
            case Screen.RETURN:
                _currentScreen = returnScreen;
                break;
            case Screen.GAME:
                _currentScreen = gameScreen;
                break;
        }

        _currentScreen.SetActive(true);
    }
}
