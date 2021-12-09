using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAdsShower
{
    void ShowInterstitial();

    void ShowRewarded(Action OnSuccess);
}
