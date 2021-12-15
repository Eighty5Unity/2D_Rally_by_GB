using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesRepository : BaseRepository<int, IAbility, AbilityConfig>, IAbilityRepository
{
    public AbilitiesRepository(IEnumerable<AbilityConfig> configs) : base(configs)
    {

    }

    protected override IAbility CreateItem(AbilityConfig config)
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
