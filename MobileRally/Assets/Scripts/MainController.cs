using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : BaseController
{
    private readonly PlayerData _model;
    private readonly Transform _uiRoot;
    private BaseController _current; //текущий контроллер

    public MainController(PlayerData model, Transform uiRoot)
    {
        _model = model;
        _uiRoot = uiRoot;

    
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
                _current = new MenuController(_model, _uiRoot);
                break;
            case GameStateEnum.ChooseInputController:
                _current = new ChooseInputController(_model, _uiRoot);
                break;
            case GameStateEnum.Game:
                _current = new GameController(_model, _uiRoot);
                break;
            default:
                break;
        }
    }
}
