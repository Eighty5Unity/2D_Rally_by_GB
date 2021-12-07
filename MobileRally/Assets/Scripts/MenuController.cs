using UnityEngine;

public class MenuController : BaseController
{
    private readonly PlayerData _playerData;
    private readonly Transform _uiRoot;

    public MenuController(PlayerData playerData, Transform uiRoot)
    {
        _playerData = playerData;
        _uiRoot = uiRoot;

    }

    private void StartGame()
    {
        _playerData.GameState.Value = GameStateEnum.Game;
    }
}

