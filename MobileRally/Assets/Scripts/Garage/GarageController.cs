using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class GarageController : BaseController, IShedController
{
    private readonly Car _car;
    private readonly UpgradeHandlersRepository _upgradeHandlersRepository;
    private readonly ItemsRepository _upgradeItemsRepository;
    private readonly InvertoryModel _inventoryModel;

    public GarageController([NotNull] List<UpgardeItemConfig> upgardeItemConfigs, [NotNull] Car car, InvertoryModel invertoryModel)
    {
        _car = car;
        _upgradeHandlersRepository = new UpgradeHandlersRepository(upgardeItemConfigs);
        AddController(_upgradeHandlersRepository);

        _upgradeItemsRepository = new ItemsRepository(upgardeItemConfigs.Select(KeyValuePair => KeyValuePair.ItemConfig).ToList());
        AddController(_upgradeItemsRepository);

        _inventoryModel = invertoryModel;
    }

    public void Enter()
    {
        Debug.Log(_car.Speed);
    }

    public void Exit()
    {
        UpgradeCarWithEquippedItems(_car, _inventoryModel.GetEquippedItems(), _upgradeHandlersRepository.UpgradeItems);
        
    }

    private void UpgradeCarWithEquippedItems(IUpgradableCar upgradableCar, IReadOnlyList<IItem> equippedItems, IReadOnlyDictionary<int, IUpgradeCarHandler> upgradeHandlers)
    {
        foreach(var equippedItem in equippedItems)
        {
            if(upgradeHandlers.TryGetValue(equippedItem.Id, out var handler))
            {
                handler.Upgrade(upgradableCar);
            }
        }
    }
}
