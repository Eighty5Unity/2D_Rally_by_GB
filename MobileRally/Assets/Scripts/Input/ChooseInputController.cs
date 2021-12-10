using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseInputController : BaseController
{
    private readonly PlayerData _model;
    private readonly IAnalytics _analytics;
    private ResourcePath _chooseInputViewResource = new ResourcePath() { PathResource = "Prefabs/chooseInputMenu" };
    private ChooseInputView _chooseInput;

    public ChooseInputController(PlayerData model, Transform uiRoot, IAnalytics analytics)
    {
        _model = model;
        _analytics = analytics;
        var prefab = ResourceLoader.LoadPrefab(_chooseInputViewResource);
        var go = GameObject.Instantiate(prefab, uiRoot);
        AddGameObject(go);
        _chooseInput = go.GetComponent<ChooseInputView>();
        _chooseInput.OnJoystickButtonClick += JoystickControll;
        _chooseInput.OnTouchButtonClick += TouchControll;
        _chooseInput.OnButtonsButtonClick += ButtonsControll;
        _chooseInput.OnGyroscopeButtonClick += GyroscopeControll;
    }

    private void JoystickControll()
    {
        _analytics.TrackEvent("Joystick", null);
        _model.InputState.Value = InputControllsEnum.Joystick;
        _model.GameState.Value = GameStateEnum.Game;
    }

    private void TouchControll()
    {
        _analytics.TrackEvent("Touch", null);
        _model.InputState.Value = InputControllsEnum.Touch;
        _model.GameState.Value = GameStateEnum.Game;
    }

    private void ButtonsControll()
    {
        _analytics.TrackEvent("Buttons", null);
        _model.InputState.Value = InputControllsEnum.Buttons;
        _model.GameState.Value = GameStateEnum.Game;
    }

    private void GyroscopeControll()
    {
        _analytics.TrackEvent("Gyroscope", null);
        _model.InputState.Value = InputControllsEnum.Guroscope;
        _model.GameState.Value = GameStateEnum.Game;
    }
}
