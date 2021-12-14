using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgradeCarHandler : IUpgradeCarHandler
{
    private float _speed;

    public SpeedUpgradeCarHandler(float speed)
    {
        _speed = speed;
    }

    public IUpgradableCar Upgrade(IUpgradableCar upgradableCar)
    {
        upgradableCar.Speed = _speed;
        return upgradableCar;
    }
}
