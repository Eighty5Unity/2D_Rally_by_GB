using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : IInventoryView
{
    public void Display(IReadOnlyList<IItem> items)
    {
       foreach(var item in items)
        {
            Debug.Log($"{item.Id}, {item.Info.Title}");
        }
    }

    public void Hide()
    {
        throw new System.NotImplementedException();
    }
}
