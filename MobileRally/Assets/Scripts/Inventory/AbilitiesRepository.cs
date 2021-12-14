using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesRepository : BaseController, IAbilityRepository
{
    private Dictionary<int, IAbility> _map = new Dictionary<int, IAbility>();

    public IReadOnlyDictionary<int, IAbility> AbilityMapById => _map;

    public AbilitiesRepository(List<AbilityConfig> configs)
    {
        PopulateAbilities(configs, ref _map);
    }

    private void PopulateAbilities(List<AbilityConfig> configs, ref Dictionary<int, IAbility> map)
    {
        foreach(var config in configs)
        {
            if (map.ContainsKey(config.Id))
            {
                continue;
            }
            map[config.Id] = CreateAbility(config);
        }
    }

    private IAbility CreateAbility(AbilityConfig config)
    {
        switch (config.Type)
        {
            case AbilityType.None:
                return new AbilityStub();
            case AbilityType.Gun:
                return new GunAbility(config.Power, config.View);
            default:
                return new AbilityStub();
        }
    }
}
