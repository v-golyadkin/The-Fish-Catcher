using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreensManager : MonoBehaviour
{
    public static ScreensManager instance;

    private GameObject _currentScreen;

    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _mainScreen;
    [SerializeField] private GameObject _returnScreen;

    [SerializeField] private Button _lengthButton;
    [SerializeField] private Button _strengthButton;
    [SerializeField] private Button _offlineButton;

    [SerializeField] private Text _gameScreenMoney;
    [SerializeField] private Text _lengthCostText;
    [SerializeField] private Text _lengthValueText;
    [SerializeField] private Text _strengthCostText;
    [SerializeField] private Text _strengthValueText;
    [SerializeField] private Text _offlineCostText;
    [SerializeField] private Text _offlineValueText;
    [SerializeField] private Text _endScreenMoney;
    [SerializeField] private Text _returnScreenMoney;

    private int _gameCount;

    private void Awake()
    {
        if (ScreensManager.instance != null)
            Destroy(gameObject);
        else
            instance = this;

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
        _endScreenMoney.text = $"${IdleManager.instance.totalGain}";
    }

    public void SetReturnScreenMoney()
    {
        _returnScreenMoney.text = $"${IdleManager.instance.totalGain} gained while waiting";
    }

    private void UpdateTexts()
    {
        _gameScreenMoney.text = $"${IdleManager.instance.wallet}";
        _lengthCostText.text = $"${IdleManager.instance.lengthCost}";
        _lengthValueText.text = $"{-IdleManager.instance.length} m";
        _strengthCostText.text = $"${IdleManager.instance.strengthCost}";
        _strengthValueText.text = $"{IdleManager.instance.strength} fishes";
        _offlineCostText.text = $"${IdleManager.instance.offlineEarningsCost}";
        _offlineValueText.text = $"${IdleManager.instance.offlineEarnings} /min";
    }

    private void CheckIdles()
    {
        int lengthCost = IdleManager.instance.lengthCost;
        int strengthCost = IdleManager.instance.strengthCost;
        int offlineEarningsCost = IdleManager.instance.offlineEarningsCost;
        int wallet = IdleManager.instance.wallet;

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
