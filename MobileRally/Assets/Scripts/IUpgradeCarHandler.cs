using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradeCarHandler
{
    IUpgradableCar Upgrade(IUpgradableCar upgradableCar);
}
