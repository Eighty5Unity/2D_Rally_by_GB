using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandlersRepository : BaseController
{
    public IReadOnlyDictionary<int, IUpgradeCarHandler> UpgradeItems => _upgradeItemsMapById;
    private Dictionary<int, IUpgradeCarHandler> _upgradeItemsMapById = new Dictionary<int, IUpgradeCarHandler>();

    public UpgradeHandlersRepository(List<UpgardeItemConfig> upgradeItemsConfig)
    {
        PopulateItems(ref _upgradeItemsMapById, upgradeItemsConfig);
    }

    private void PopulateItems(
        ref Dictionary<int, IUpgradeCarHandler> upgradeHandlersMapByType,
        List<UpgardeItemConfig> configs)
    {
        foreach(var config in configs)
        {
            if (upgradeHandlersMapByType.ContainsKey(config.Id))
            {
                continue;
            }
            upgradeHandlersMapByType.Add(config.Id, CreateHandlerByType(config));
        }
    }

    private IUpgradeCarHandler CreateHandlerByType(UpgardeItemConfig config)
    {
        switch (config.UpgradeType)
        {
            case UpgradeType.Speed:
                return new SpeedUpgradeCarHandler(config.ValueUpgrade);
            default:
                return StubUpgradeCarHandler.Default;
        }
    }

    protected override void OnDispose()
    {
        _upgradeItemsMapById.Clear();
        _upgradeItemsMapById = null;
    }
}
