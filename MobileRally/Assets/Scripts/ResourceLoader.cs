using System;
using UnityEngine;

public class ResourceLoader
{
    public static GameObject LoadPrefab(ResourcePath path)
    {
        return Resources.Load<GameObject>(path.PathResource);
    }

    public static IConfigContainer<TConfig> LoadConfigContainer<TConfig>(ResourcePath path) where TConfig : IUnique<int>
    {
        var so = Resources.Load<ScriptableObject>(path.PathResource);
        var container = so as IConfigContainer<TConfig>;
        if(container == null)
        {
            throw new ArgumentException("not IConfigContainer");
        }
        return container;
    }
}
