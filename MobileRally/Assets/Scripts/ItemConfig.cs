using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemConfig : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _title;

    public int ID => _id;

    public string Title => _title;
}
