using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class InitializeAds : MonoBehaviour, IUnityAdsInitializationListener
{
    public string androidGameId = "5485055";
    public string iosGameId = "5485054";

    public bool isTestingMode = true;

    string gameId;

    void Awake()
    {
        OnInitializeAds();
    }

    void OnInitializeAds()
    {


#if UNITY_IOS
        gameId = iosGameId;
#elif UNITY_ANDROID
        gameId = androidGameId;
#elif UNITY_EDITOR
        gameId = androidGameId;//for testing
#endif

        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, isTestingMode, this);//ONLY ONCE
        }

    }

    public void OnInitializationComplete()
    {
        //print("Ads initialized!!");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        print("failed to initialize!!");
    }
}