using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem 
{
    int Id { get; }

    ItemInfo Info { get; }
}
