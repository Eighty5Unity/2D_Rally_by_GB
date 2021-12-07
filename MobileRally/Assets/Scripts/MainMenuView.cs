using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    public Action OnStartButtonClick;

    private void Awake()
    {
        _startButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        OnStartButtonClick?.Invoke();
    }
}
