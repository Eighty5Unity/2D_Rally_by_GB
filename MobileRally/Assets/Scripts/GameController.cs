using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseController
{
    private readonly PlayerData _model;

    private SubscriptionProperty<float> _leftMove;
    private SubscriptionProperty<float> _rightMove;

    public GameController(PlayerData model, Transform uiRoot)
    {
        _model = model;
        _leftMove = new SubscriptionProperty<float>();
        _rightMove = new SubscriptionProperty<float>();

        var bg = new BackgroundController(_model, _leftMove, _rightMove);
        var car = new CarController(_model);
        var input = new InputController(_model, _leftMove, _rightMove, uiRoot);
    }
}
