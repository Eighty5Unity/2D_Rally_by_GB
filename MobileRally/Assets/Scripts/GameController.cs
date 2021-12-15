using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseController
{
    private readonly PlayerData _model;
    private readonly InvertoryModel _inventoryModel;
    private readonly ResourcePath _viewPath = new ResourcePath() { PathResource = "Prefabs/Car" };
    private SubscriptionProperty<float> _leftMove;
    private SubscriptionProperty<float> _rightMove;

    public GameController(PlayerData model, Transform uiRoot, InvertoryModel inventoryModel, IAbilityRepository abilitiesRepository)
    {
        _model = model;
        _inventoryModel = inventoryModel;
        _leftMove = new SubscriptionProperty<float>();
        _rightMove = new SubscriptionProperty<float>();

        var bg = new BackgroundController(_model, _leftMove, _rightMove);
        AddController(bg);

        var carView = LoadView();
        var car = new CarController(carView);
        AddController(car);

        var input = new InputController(_model, _leftMove, _rightMove, uiRoot);
        AddController(input);

        var abilitiesController = new AbilitiesController(_inventoryModel, abilitiesRepository, new AbilityCollectionViewStub(), car);
        AddController(abilitiesController);
    }

    private ICarView LoadView()
    {
        var objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
        AddGameObject(objView);

        return objView.GetComponent<ICarView>();
    }
}
