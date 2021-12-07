using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Transform _uiRoot;
    private MainController _mainController;

    private void Start()
    {
        PlayerData playerData = new PlayerData();
        playerData.GameState.Value = GameStateEnum.Start;
        _mainController = new MainController(playerData, _uiRoot);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
        _mainController = null;
    }
}
