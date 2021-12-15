using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : BaseController
{
    private ResourcePath _backgroundResourse = new ResourcePath() { PathResource = "Prefabs/background" };

    private readonly PlayerData _model;
    private readonly SubscriptionProperty<float> _leftMove;
    private readonly SubscriptionProperty<float> _rightMove;
    private readonly TapeBackgroundView _background;

    public BackgroundController(PlayerData model, SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove)
    {
        _model = model;
        _leftMove = leftMove;
        _rightMove = rightMove;

        var prefab = ResourceLoader.LoadPrefab(_backgroundResourse);
        var go = GameObject.Instantiate(prefab);
        _background = go.GetComponent<TapeBackgroundView>();

        leftMove.SubscribeOnChange(OnLeftMove);
        rightMove.SubscribeOnChange(OnRightMove);
    }

    private void OnLeftMove(float value)
    {
        _background.Move(value);
    }

    private void OnRightMove(float value)
    {
        _background.Move(value);
    }
}
