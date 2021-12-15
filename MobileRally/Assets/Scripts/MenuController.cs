using System.Collections.Generic;
using UnityEngine;

public class MenuController : BaseController
{
    private readonly PlayerData _playerData;
    private readonly IAdsShower _ads;
    private MainMenuView _menuView;
    private readonly GarageController _garageController;
    private readonly InvertoryModel _inventoryModel;
    private ResourcePath _menuViewResource = new ResourcePath() { PathResource = "Prefabs/mainMenu" };
    private ResourcePath _touchViewPath = new ResourcePath() { PathResource = "Prefabs/TrailRenderer" };
    private readonly TrailsTouchView _trailsView;

    public MenuController(PlayerData playerData, Transform uiRoot, IAdsShower ads, List<UpgardeItemConfig> upgradeItems, InvertoryModel invertoryModel)
    {
        _playerData = playerData;
        _ads = ads;
        _inventoryModel = invertoryModel;

        var prefab = ResourceLoader.LoadPrefab(_menuViewResource);
        var go = GameObject.Instantiate(prefab, uiRoot);
        AddGameObject(go);
        _menuView = go.GetComponent<MainMenuView>();
        _menuView.OnStartButtonClick += StartGame;
        _menuView.OnRewardedButtonClick += ShowRewarded;
        _garageController = new GarageController(upgradeItems, _playerData.Car, _inventoryModel);
        _garageController.Enter();
        _garageController.Exit();
        _trailsView = CreateTrailsView(uiRoot);
        _trailsView.Init();
    }

    private void StartGame()
    {
        _playerData.GameState.Value = GameStateEnum.ChooseInputController;
    }

    protected override void OnDispose()
    {
        _menuView.OnStartButtonClick -= StartGame;
        _menuView.OnRewardedButtonClick -= ShowRewarded;
        base.OnDispose();
    }

    private void ShowRewarded()
    {
        _ads.ShowRewarded(() => Debug.Log("Show Rewarded"));
    }

    private TrailsTouchView CreateTrailsView(Transform uiRoot)
    {
        var trailView = Object.Instantiate(ResourceLoader.LoadPrefab(_touchViewPath), uiRoot, false).GetComponent<TrailsTouchView>();
        AddGameObject(trailView.gameObject);
        return trailView;
    }
}
