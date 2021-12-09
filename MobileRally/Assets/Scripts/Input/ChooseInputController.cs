using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseInputController : BaseController
{
    private readonly PlayerData _model;
    private ResourcePath _chooseInputViewResource = new ResourcePath() { PathResource = "Prefabs/chooseInputMenu" };
    private ChooseInputView _chooseInput;

    public ChooseInputController(PlayerData model, Transform uiRoot)
    {
        _model = model;
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
        _model.InputState.Value = InputControllsEnum.Joystick;
        _model.GameState.Value = GameStateEnum.Game;
    }

    private void TouchControll()
    {
        _model.InputState.Value = InputControllsEnum.Touch;
        _model.GameState.Value = GameStateEnum.Game;
    }

    private void ButtonsControll()
    {
        _model.InputState.Value = InputControllsEnum.Buttons;
        _model.GameState.Value = GameStateEnum.Game;
    }

    private void GyroscopeControll()
    {
        _model.InputState.Value = InputControllsEnum.Guroscope;
        _model.GameState.Value = GameStateEnum.Game;
    }
}
