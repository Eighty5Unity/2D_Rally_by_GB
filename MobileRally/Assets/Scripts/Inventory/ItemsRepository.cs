using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsRepository : BaseController, IItemRepository
{
    private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();

    public IReadOnlyDictionary<int, IItem> Items => _itemsMapById;

    public ItemsRepository(List<ItemConfig> upgradeItemsConfig)
    {
        PopulateItems(ref _itemsMapById, upgradeItemsConfig);
    }

    private void PopulateItems(ref Dictionary<int, IItem> upgradeHandlerMapById, List<ItemConfig> configs)
    {
        foreach(var config in configs)
        {
            if (upgradeHandlerMapById.ContainsKey(config.ID))
            {
                continue;
            }

            upgradeHandlerMapById.Add(config.ID, CreateItem(config));
        }
    }

    private IItem CreateItem(ItemConfig config)
    {
        return new Item { Id = config.ID, Info = new ItemInfo { Title = config.Title } };
    }

    protected override void OnDispose()
    {
        _itemsMapById.Clear();
        _itemsMapById = null;
    }
}
