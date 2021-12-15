using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Transform _uiRoot;
    [SerializeField] private UnityAdsTools _ads;
    
    private ResourcePath _itemsPath = new ResourcePath() { PathResource = "Configs/ItemsConfigContainer" };
    private ResourcePath _abilitiesPath = new ResourcePath() { PathResource = "Configs/AbilitiesConfigContainer" };

    [SerializeField] private UpgardeItemConfig[] _upgradeItemsConfig;
    private MainController _mainController;

    private void Start()
    {
        PlayerData playerData = new PlayerData();
        var analytics = new UnityAnalyticsHandler();
        var itemsConfig = ResourceLoader.LoadConfigContainer<ItemConfig>(_itemsPath);
        var abilitiesConfig = ResourceLoader.LoadConfigContainer<AbilityConfig>(_abilitiesPath);
        playerData.GameState.Value = GameStateEnum.Start;
        _mainController = new MainController(playerData, _uiRoot, _ads, analytics, itemsConfig,
            abilitiesConfig, _upgradeItemsConfig.ToList());
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
        _mainController = null;
    }
}
