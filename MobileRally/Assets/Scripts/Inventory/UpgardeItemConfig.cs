using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Upgrade Item", menuName = "Upgrade Item")]
public class UpgardeItemConfig : ScriptableObject
{
    [SerializeField] private ItemConfig _itenConfig;
    [SerializeField] private UpgradeType _upgradeType;
    [SerializeField] private float _valueUpgrade;

    public int Id => _itenConfig.ID;

    public ItemConfig ItemConfig => _itenConfig;

    public UpgradeType UpgradeType => _upgradeType;

    public float ValueUpgrade => _valueUpgrade;
}
