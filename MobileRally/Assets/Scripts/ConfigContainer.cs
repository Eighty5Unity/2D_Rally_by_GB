using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class ConfigContainer<TConfig> : ScriptableObject, IConfigContainer<TConfig> where TConfig : IUnique<int>
{

    [SerializeField] private List<TConfig> _configs = new List<TConfig>();

    public IReadOnlyList<TConfig> Configs => _configs;
}
