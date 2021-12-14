using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesRepositoryStub : IAbilityRepository
{
    public IReadOnlyDictionary<int, IAbility> AbilityMapById { get; } = new Dictionary<int, IAbility>();
}
