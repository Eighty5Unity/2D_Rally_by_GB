using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertoryController : BaseController, IInvertoryController
{
    private readonly IItemRepository _itemsRepository;
    private readonly IInventoryModel _inventoryModel;
    private readonly IInventoryView _inventoryWindowView;

    public InvertoryController(IInventoryModel inventoryModel, IItemRepository itemsRepository)
    {
        _inventoryModel = inventoryModel;
        _itemsRepository = itemsRepository;
        _inventoryWindowView = new InventoryView();
    }

    public void ShowInventory()
    {
        foreach(var item in _itemsRepository.Items.Values)
        {
            _inventoryModel.EquipItem(item);
        }

        var equippedItems = _inventoryModel.GetEquippedItems();
        _inventoryWindowView.Display(equippedItems);
    }
}
