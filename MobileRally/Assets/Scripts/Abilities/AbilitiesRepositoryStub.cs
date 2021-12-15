using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesRepositoryStub : IAbilityRepository
{
    public IReadOnlyDictionary<int, IAbility> Items { get; } = new Dictionary<int, IAbility>();
}
