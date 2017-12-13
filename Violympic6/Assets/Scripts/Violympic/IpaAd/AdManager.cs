using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour {


    #region Singleton
    private static AdManager _instance;

    public static AdManager instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<AdManager>();
            return _instance;
        }
    }
    #endregion

    InterstitialAd interstitial;


    BannerView bannerView;

    private void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(Config.adsID, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
		AdRequest request = new AdRequest.Builder().TagForChildDirectedTreatment(true).AddExtra("is_designed_for_families", "true").Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }
    public void ShowBanner()
    {
        RequestBanner();
        bannerView.Show();
    }

    public void HideBaner()
    {
        bannerView.Hide();
    }

    public void LoadAdsInterstitial()
    {
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(Config.adsInID);
        // Create an empty ad request.
		AdRequest requestIN = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("365BCE5DDF729BFD1E6E40D79CE8F42B").TagForChildDirectedTreatment(true).AddExtra("is_designed_for_families", "true").Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(requestIN);
    }



    public void ShowAdsInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void HideAdsInterstitial()
    {
        interstitial.Destroy();
    }

	// Use this for initialization
	void Start () {
        MobileAds.Initialize(Config.appId);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
