using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseInputController : BaseController
{
    private readonly PlayerData _model;
    private ResourcePath _chooseInputViewResource = new ResourcePath() { PathResource = "Prefabs/chooseInputMenu" };

    public ChooseInputController(PlayerData model, Transform uiRoot)
    {
        _model = model;
        var prefab = ResourceLoader.LoadPrefab(_chooseInputViewResource);
        var go = GameObject.Instantiate(prefab, uiRoot);
        AddGameObject(go);

    }
}
