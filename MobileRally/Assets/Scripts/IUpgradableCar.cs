using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradableCar 
{
    float Speed { get; set; }

    void Restore();
}
