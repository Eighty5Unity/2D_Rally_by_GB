using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilitiesController : BaseController
{
    private readonly IInventoryModel _inventory;
    private readonly IAbilityRepository _abilityRepository;
    private readonly IAbilityCollectionView _view;
    private readonly IAbilityActivator _activator;

    public AbilitiesController(IInventoryModel inventory, IAbilityRepository abilitiesRepository,
        IAbilityCollectionView view, IAbilityActivator activator)
    {
        _inventory = inventory;
        _abilityRepository = abilitiesRepository;
        _view = view;
        _activator = activator;

        var equiped = inventory.GetEquippedItems();
        var equipedAbilities = equiped.Where(i => _abilityRepository.Items.ContainsKey(i.Id));
        view.Display(equipedAbilities.ToList());
        view.UseRequested += OnAbilityRequested;
    }

    private void OnAbilityRequested(object sender, IItem e)
    {
        var ability = _abilityRepository.Items[e.Id];
        ability.Apply(_activator);
    }
}
