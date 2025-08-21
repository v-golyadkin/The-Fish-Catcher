using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreensManager : MonoBehaviour
{
    public static ScreensManager Instance;

    private GameObject _currentScreen;

    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _mainScreen;
    [SerializeField] private GameObject _returnScreen;

    [SerializeField] private Button _lengthButton;
    [SerializeField] private Button _strengthButton;
    [SerializeField] private Button _offlineButton;

    [SerializeField] private TMP_Text _gameScreenMoney;
    [SerializeField] private TMP_Text _lengthPriceText;
    [SerializeField] private TMP_Text _lengthValueText;
    [SerializeField] private TMP_Text _strengthPriceText;
    [SerializeField] private TMP_Text _strengthValueText;
    [SerializeField] private TMP_Text _offlinePriceText;
    [SerializeField] private TMP_Text _offlineValueText;
    [SerializeField] private TMP_Text _endScreenMoney;
    [SerializeField] private TMP_Text _returnScreenMoney;

    private int _gameCount;

    private void Awake()
    {
        if (ScreensManager.Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        _currentScreen = _mainScreen;
    }

    private void Start()
    {
        CheckIdles();
        UpdateTexts();
    }

    public void ChangeScreen(Screens screen)
    {
        _currentScreen.SetActive(false);
        switch(screen)
        {
            case Screens.MAIN:
                _currentScreen = _mainScreen;
                UpdateTexts();
                CheckIdles();
                break;

            case Screens.GAME:
                _currentScreen = _gameScreen;
                _gameCount++;
                break;
            case Screens.END:
                _currentScreen = _endScreen;
                SetEndScreenMoney();
                break;
            case Screens.RETURN:
                _currentScreen = _returnScreen;
                SetReturnScreenMoney();
                break;
        }
        _currentScreen.SetActive(true);
    }

    public void SetEndScreenMoney()
    {
        _endScreenMoney.text = $"${IdleManager.Instance.totalGain}";
    }

    public void SetReturnScreenMoney()
    {
        _returnScreenMoney.text = $"${IdleManager.Instance.totalGain} gained while waiting";
    }

    private void UpdateTexts()
    {
        _gameScreenMoney.text = $"${IdleManager.Instance.wallet}";
        _lengthPriceText.text = $"${IdleManager.Instance.LengthUpgradePrice}";
        _lengthValueText.text = $"{-IdleManager.Instance.Length} m";
        _strengthPriceText.text = $"${IdleManager.Instance.StrengthUpgradePrice}";
        _strengthValueText.text = $"{IdleManager.Instance.Strength} fishes";
        _offlinePriceText.text = $"${IdleManager.Instance.OfflineEarningsUpdatePrice}";
        _offlineValueText.text = $"${IdleManager.Instance.OfflineEarnings} /min";
    }

    private void CheckIdles()
    {
        int lengthCost = IdleManager.Instance.LengthUpgradePrice;
        int strengthCost = IdleManager.Instance.StrengthUpgradePrice;
        int offlineEarningsCost = IdleManager.Instance.OfflineEarningsUpdatePrice;
        int wallet = IdleManager.Instance.wallet;

        if(wallet < lengthCost)
            _lengthButton.interactable = false;
        else 
            _lengthButton.interactable = true;

        if(wallet < strengthCost)
            _strengthButton.interactable = false;
        else
            _strengthButton.interactable = true;

        if(wallet < offlineEarningsCost)
            _offlineButton.interactable = false;
        else
            _offlineButton.interactable = true;
    }
}
