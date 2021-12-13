using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShop 
{
    void Buy(string productId);

    string GetCost(string productId);

    void RestorePurchase();

    Action<string> OnSuccessPurchase { get; }
    Action<string> OnFailedPurchase { get; }
}
