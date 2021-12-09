using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsTools : MonoBehaviour, IAdsShower, IUnityAdsListener
{
    private const string IOS_GAMEID = "4497105";
    private const string IOS_INTERSTITIAL = "Interstitial_iOS";
    private const string IOS_REWARDED = "Rewarded_iOS";

    private bool _isInitialized = false;
    private Action _onRewardedSuccess;

    private void Start()
    {
        Advertisement.Initialize(IOS_GAMEID);
    }

    public void ShowInterstitial()
    {
        Advertisement.Show(IOS_INTERSTITIAL);
    }

    public void ShowRewarded(Action OnSuccess)
    {
        _onRewardedSuccess = OnSuccess;
        Advertisement.Show(IOS_REWARDED);
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log(message);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        _onRewardedSuccess?.Invoke();
        _onRewardedSuccess = null;
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log($"Placment ready {placementId}");
        _isInitialized = true;
    }
}
