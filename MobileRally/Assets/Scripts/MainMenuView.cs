using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _showRewarded;

    public Action OnStartButtonClick;
    public Action OnRewardedButtonClick;

    private void Awake()
    {
        _startButton.onClick.AddListener(OnButtonClick);
        _showRewarded.onClick.AddListener(ShowAd);
    }

    private void OnButtonClick()
    {
        OnStartButtonClick?.Invoke();
    }

    private void ShowAd()
    {
        OnRewardedButtonClick?.Invoke();
    }
}
