using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseInputView : MonoBehaviour
{
    [SerializeField] private Button _joystickButton;
    [SerializeField] private Button _touchButton;
    [SerializeField] private Button _buttonsButton;
    [SerializeField] private Button _gyroscopeButton;

    public Action OnJoystickButtonClick;
    public Action OnTouchButtonClick;
    public Action OnButtonsButtonClick;
    public Action OnGyroscopeButtonClick;

    private void Awake()
    {
        _joystickButton.onClick.AddListener(JoystickButtonClick);
        _touchButton.onClick.AddListener(TouchButtonClick);
        _buttonsButton.onClick.AddListener(ButtonsButtonClick);
        _gyroscopeButton.onClick.AddListener(GyroscopeButtonClick);
    }

    private void JoystickButtonClick()
    {
        OnJoystickButtonClick?.Invoke();
    }

    private void TouchButtonClick()
    {
        OnTouchButtonClick?.Invoke();
    }

    private void ButtonsButtonClick()
    {
        OnButtonsButtonClick?.Invoke();
    }

    private void GyroscopeButtonClick()
    {
        OnGyroscopeButtonClick?.Invoke();
    }
}
