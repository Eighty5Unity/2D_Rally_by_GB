using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability Item", menuName = "Ability Item")]
public class AbilityConfig : ScriptableObject
{
    [SerializeField] private ItemConfig _item;
    [SerializeField] private float _power;
    [SerializeField] private AbilityType _type;
    [SerializeField] private ResourcePath _view;

    public int Id => _item.ID;

    public float Power => _power;

    public AbilityType Type => _type;

    public ResourcePath View => _view;
}
