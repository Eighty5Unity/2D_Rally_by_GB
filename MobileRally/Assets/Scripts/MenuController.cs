using UnityEngine;

public class MenuController : BaseController
{
    private readonly PlayerData _playerData;
    private readonly IAdsShower _ads;
    private MainMenuView _menuView;
    private ResourcePath _menuViewResource = new ResourcePath() { PathResource = "Prefabs/mainMenu" };

    public MenuController(PlayerData playerData, Transform uiRoot, IAdsShower ads)
    {
        _playerData = playerData;
        _ads = ads;

        var prefab = ResourceLoader.LoadPrefab(_menuViewResource);
        var go = GameObject.Instantiate(prefab, uiRoot);
        AddGameObject(go);
        _menuView = go.GetComponent<MainMenuView>();
        _menuView.OnStartButtonClick += StartGame;
        _menuView.OnRewardedButtonClick += ShowRewarded;
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
}
