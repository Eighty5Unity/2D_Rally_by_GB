using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : BaseController
{
    private readonly PlayerData _model;
    private readonly Transform _uiRoot;
    private readonly IAdsShower _adsShower;
    private readonly IAnalytics _analytics;
    private BaseController _current; //текущий контроллер


    public MainController(PlayerData model, Transform uiRoot, IAdsShower adsShower, IAnalytics analytics)
    {
        _model = model;
        _uiRoot = uiRoot;
        _adsShower = adsShower;
        _analytics = analytics;

    
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
                _current = new MenuController(_model, _uiRoot, _adsShower);
                break;
            case GameStateEnum.ChooseInputController:
                _adsShower.ShowRewarded(() => Debug.Log("Show Rewarded"));
                _current = new ChooseInputController(_model, _uiRoot, _analytics);
                break;
            case GameStateEnum.Game:
                _analytics.TrackEvent("game_start", null);
                _current = new GameController(_model, _uiRoot);
                break;
            default:
                break;
        }
    }
}
