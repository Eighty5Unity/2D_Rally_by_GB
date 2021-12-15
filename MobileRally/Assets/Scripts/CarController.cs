using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : BaseController, IAbilityActivator
{
    private readonly ICarView _carView;


    public CarController(ICarView carView)
    {
        _carView = carView;
    }

    public GameObject GetViewObject()
    {
        return _carView.GameObject;
    }
}
