using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRepository<TKey, TValue> 
{
    IReadOnlyDictionary<TKey, TValue> Items { get; }
}
