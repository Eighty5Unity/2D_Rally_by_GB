using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Transform _uiRoot;
    [SerializeField] private UnityAdsTools _ads;
    [SerializeField] private ItemConfig[] _itemsConfig;
    [SerializeField] private AbilityConfig[] _abilitiesConfig;
    [SerializeField] private UpgardeItemConfig[] _upgradeItemsConfig;
    private MainController _mainController;

    private void Start()
    {
        PlayerData playerData = new PlayerData();
        var analytics = new UnityAnalyticsHandler();
        playerData.GameState.Value = GameStateEnum.Start;
        _mainController = new MainController(playerData, _uiRoot, _ads, analytics, _itemsConfig.ToList(),
            _abilitiesConfig.ToList(), _upgradeItemsConfig.ToList());
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
        _mainController = null;
    }
}
