using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : IDisposable
{
    private List<BaseController> _baseControllers = new List<BaseController>();
    private List<GameObject> _gameObjects = new List<GameObject>();
    private bool _isDisposed;

    protected void AddController(BaseController controller)
    {
        _baseControllers.Add(controller);
    }

    protected void AddGameObject(GameObject gameObject)
    {
        _gameObjects.Add(gameObject);
    }

    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        OnDispose();

        _isDisposed = true;

        foreach(BaseController baseController in _baseControllers)
        {
            baseController?.Dispose();
        }
        _baseControllers.Clear();

        foreach(GameObject gameObject in _gameObjects)
        {
            UnityEngine.Object.Destroy(gameObject);
        }
        _gameObjects.Clear();
    }

    protected virtual void OnDispose()
    {
        //тут можно добавить собственную логику очистки
    }
}
