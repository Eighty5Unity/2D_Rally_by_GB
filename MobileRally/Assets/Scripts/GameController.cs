using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseController
{
    private readonly PlayerData _model;
    private readonly InvertoryModel _inventoryModel;

    private SubscriptionProperty<float> _leftMove;
    private SubscriptionProperty<float> _rightMove;

    public GameController(PlayerData model, Transform uiRoot, InvertoryModel inventoryModel, IAbilityRepository abilitiesRepository)
    {
        _model = model;
        _inventoryModel = inventoryModel;
        _leftMove = new SubscriptionProperty<float>();
        _rightMove = new SubscriptionProperty<float>();

        var bg = new BackgroundController(_model, _leftMove, _rightMove);
        var car = new CarController();
        var input = new InputController(_model, _leftMove, _rightMove, uiRoot);
        var abilitiesController = new AbilitiesController(inventoryModel, abilitiesRepository, new AbilityCollectionViewStub(), car);
    }
}
