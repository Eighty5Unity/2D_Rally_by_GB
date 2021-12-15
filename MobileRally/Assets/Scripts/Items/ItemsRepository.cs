using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsRepository : BaseRepository<int, IItem, ItemConfig>, IItemRepository
{
    public ItemsRepository(IEnumerable<ItemConfig> configs) : base(configs)
    {

    }

    protected override IItem CreateItem(ItemConfig config)
    {
        return new Item { Id = config.Id, Info = new ItemInfo { Title = config.Title } };
    }
}
