using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Transform _uiRoot;
    [SerializeField] private UnityAdsTools _ads;
    private MainController _mainController;

    private void Start()
    {
        PlayerData playerData = new PlayerData();
        var analytics = new UnityAnalyticsHandler();
        playerData.GameState.Value = GameStateEnum.Start;
        _mainController = new MainController(playerData, _uiRoot, _ads, analytics);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
        _mainController = null;
    }
}
