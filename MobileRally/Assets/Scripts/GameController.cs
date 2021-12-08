using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseController
{
    private readonly PlayerData _model;

    public GameController(PlayerData model, Transform uiRoot)
    {
        _model = model;
        var bg = new BackgroundController(_model);
        var car = new CarController(_model);
        var input = new InputController(_model);
    }
}
