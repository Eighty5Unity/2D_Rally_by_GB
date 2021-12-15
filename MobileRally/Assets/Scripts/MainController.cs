using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : BaseController
{
    private readonly PlayerData _model;
    private readonly Transform _uiRoot;
    private readonly IAdsShower _adsShower;
    private readonly IAnalytics _analytics;
    private readonly IConfigContainer<ItemConfig> _itemsConfig;
    private readonly IConfigContainer<AbilityConfig> _abilitiesConfig;
    private readonly List<UpgardeItemConfig> _upgradeItemsConfig;

    private InvertoryModel _inventoryModel;
    private InvertoryController _invertoryController;
    private AbilitiesRepository _abilitiesRepository;
    private ItemsRepository _itemsRepository;
    private BaseController _current; //текущий контроллер


    public MainController(PlayerData model, Transform uiRoot, IAdsShower adsShower, IAnalytics analytics,
        IConfigContainer<ItemConfig> itemsConfig, IConfigContainer<AbilityConfig> abilitiesConfig, List<UpgardeItemConfig> upgradeItemsConfig)
    {
        _model = model;
        _uiRoot = uiRoot;
        _adsShower = adsShower;
        _analytics = analytics;
        _itemsConfig = itemsConfig;
        _abilitiesConfig = abilitiesConfig;
        _upgradeItemsConfig = upgradeItemsConfig;

        _inventoryModel = new InvertoryModel();
        _itemsRepository = new ItemsRepository(_itemsConfig.Configs);
        _invertoryController = new InvertoryController(_inventoryModel, _itemsRepository, new InventoryView());
        _abilitiesRepository = new AbilitiesRepository(_abilitiesConfig.Configs);
        AddController(_invertoryController);
    
        _model.GameState.SubscribeOnChange(GameStateChange);
        _model.GameState.Value = GameStateEnum.Start;
       
    }

    private void GameStateChange(GameStateEnum state)
    {
        _current?.Dispose();
        switch (state)
        {
            case GameStateEnum.None:
                break;
            case GameStateEnum.Start:
                _analytics.TrackEvent("game_load", null);
                _invertoryController.ShowInventory();
                _current = new MenuController(_model, _uiRoot, _adsShower, _upgradeItemsConfig, _inventoryModel);
                break;
            case GameStateEnum.ChooseInputController:
                _adsShower.ShowRewarded(() => Debug.Log("Show Rewarded"));
                _current = new ChooseInputController(_model, _uiRoot, _analytics);
                break;
            case GameStateEnum.Game:
                _analytics.TrackEvent("game_start", null);
                _invertoryController.ShowInventory();
                _current = new GameController(_model, _uiRoot, _inventoryModel, _abilitiesRepository);
                break;
            default:
                break;
        }
    }
}
