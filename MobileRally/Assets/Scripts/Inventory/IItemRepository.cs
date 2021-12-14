using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemRepository 
{
    IReadOnlyDictionary<int, IItem> Items { get; }
}
