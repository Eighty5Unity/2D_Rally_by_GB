using UnityEngine;

public class MenuController : BaseController
{
    private readonly PlayerData _playerData;
    private MainMenuView _menuView;
    private ResourcePath _menuViewResource = new ResourcePath() { PathResource = "Prefabs/mainMenu" };

    public MenuController(PlayerData playerData, Transform uiRoot)
    {
        _playerData = playerData;
        var prefab = ResourceLoader.LoadPrefab(_menuViewResource);
        var go = GameObject.Instantiate(prefab, uiRoot);
        AddGameObject(go);
        _menuView = go.GetComponent<MainMenuView>();
        _menuView.OnStartButtonClick += StartGame;
    }

    private void StartGame()
    {
        _playerData.GameState.Value = GameStateEnum.Game;
    }

    protected override void OnDispose()
    {
        _menuView.OnStartButtonClick -= StartGame;
        base.OnDispose();
    }
}
