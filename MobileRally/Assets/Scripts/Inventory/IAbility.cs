using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility 
{
    void Apply(IAbilityActivator activator);
}
