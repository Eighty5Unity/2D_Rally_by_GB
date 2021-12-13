using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class ShopTools : IShop, IStoreListener
{
    private IStoreController _controller;

    public ShopTools(List<ProductData> products)
    {
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        foreach(var product in products)
        {
            builder.AddProduct(product.Id, product.Type);
        }
        UnityPurchasing.Initialize(this, builder);

    }

    public Action<string> OnSuccessPurchase => throw new NotImplementedException();

    public Action<string> OnFailedPurchase => throw new NotImplementedException();

    public void Buy(string productId)
    {
        if(_controller != null)
        {
            _controller.InitiatePurchase(productId);
        }
       
    }

    public string GetCost(string productId)
    {
        Product product = _controller.products.WithID(productId);
        if(product != null)
        {
            return product.metadata.localizedPriceString;
        }
        return "n/a";
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        _controller = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log(error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(failureReason);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        Debug.Log(purchaseEvent.purchasedProduct.definition.id);
        return PurchaseProcessingResult.Complete;
    }

    public void RestorePurchase()
    {
        throw new NotImplementedException();
    }
}
