using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JoostenProductions;

public class InputController : BaseController
{
    private ResourcePath _inputPath;
    private readonly PlayerData _model;
    private readonly SubscriptionProperty<float> _leftMove;
    private readonly SubscriptionProperty<float> _rightMove;
    private readonly BaseInputView _inputView;

    public InputController(PlayerData model, SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, Transform uiRoot)
    {
        _model = model;
        _leftMove = leftMove;
        _rightMove = rightMove;

        InputStateChange(_model.InputState.Value);

        var prefab = ResourceLoader.LoadPrefab(_inputPath);
        var go = GameObject.Instantiate(prefab, uiRoot);
        AddGameObject(go);
        _inputView = go.GetComponent<BaseInputView>();

        _inputView.Init(leftMove, rightMove, model.Car.Speed);
    }

    private void InputStateChange(InputControllsEnum state)
    {
        switch (state)
        {
            case InputControllsEnum.None:
                break;
            case InputControllsEnum.Joystick:
                _inputPath = new ResourcePath() { PathResource = "Prefabs/Controlls/JoystickControl" };
                break;
            case InputControllsEnum.Touch:
                _inputPath = new ResourcePath() { PathResource = "Prefabs/Controlls/TouchControl" };
                break;
            case InputControllsEnum.Buttons:
                _inputPath = new ResourcePath() { PathResource = "Prefabs/Controlls/ButtonsControl" };
                break;
            case InputControllsEnum.Guroscope:
                _inputPath = new ResourcePath() { PathResource = "Prefabs/Controlls/GyroscopeControl" };
                break;
            default:
                break;
        }
    }
}
