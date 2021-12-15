using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnique<Tid>
{
    Tid Id { get; }
}
