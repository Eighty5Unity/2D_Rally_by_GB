using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAbility : IAbility
{
    private readonly Rigidbody2D _viewPrefab;
    private float _speed;

    public GunAbility(float speed, ResourcePath viewPath)
    {
        _speed = speed;
        var go = ResourceLoader.LoadPrefab(viewPath);
        _viewPrefab = go.GetComponent<Rigidbody2D>();
        if(_viewPrefab == null)
        {
            throw new ArgumentException("Unable to load view");
        }
    }

    public void Apply(IAbilityActivator activator)
    {
        var projectile = GameObject.Instantiate(_viewPrefab);
        projectile.AddForce(activator.GetViewObject().transform.right * _speed);
    }
}
