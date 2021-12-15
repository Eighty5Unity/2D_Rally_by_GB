using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConfigContainer<TConfig> where TConfig : IUnique<int>
{
    IReadOnlyList<TConfig> Configs { get; }
}
