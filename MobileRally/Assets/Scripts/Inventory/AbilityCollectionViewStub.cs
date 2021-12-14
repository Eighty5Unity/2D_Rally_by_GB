using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCollectionViewStub : IAbilityCollectionView
{
    public event EventHandler<IItem> UseRequested;

    public void Display(IReadOnlyList<IItem> abilityItems)
    {
        foreach(var item in abilityItems)
        {
            Debug.Log("DZ");
        }
    }
}
