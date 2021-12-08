using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController 
{
    private ResourcePath _backgroundResourse = new ResourcePath() { PathResource = "Prefabs/background" };

    private readonly PlayerData _model;
    private readonly TapeBackgroundView _background;

    public BackgroundController(PlayerData model)
    {
        _model = model;
        var prefab = ResourceLoader.LoadPrefab(_backgroundResourse);
        var go = GameObject.Instantiate(prefab);
        _background = go.GetComponent<TapeBackgroundView>();
    }
}
