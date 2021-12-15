using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRepository<Tkey, TValue, TConfig> : BaseController, IRepository<Tkey, TValue> where TConfig : IUnique<Tkey>
{
    private Dictionary<Tkey, TValue> _items;

    public IReadOnlyDictionary<Tkey, TValue> Items => _items;

    public BaseRepository(IEnumerable<TConfig> configs)
    {
        _items = new Dictionary<Tkey, TValue>();
        PopulateItems(configs, ref _items);
    }

    private void PopulateItems(IEnumerable<TConfig> configs, ref Dictionary<Tkey, TValue> map)
    {
        foreach(var config in configs)
        {
            if (map.ContainsKey(config.Id))
            {
                continue;
            }
            map[config.Id] = CreateItem(config);
        }
    }

    protected abstract TValue CreateItem(TConfig config);
}
