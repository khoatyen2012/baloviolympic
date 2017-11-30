using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class PopUpGameOver : MonoBehaviour {

    public tk2dUIItem btnContinute;
    public tk2dUIItem btnStop;
    public tk2dUIItem btnRate;
    public tk2dTextMesh txtLevel;
    public tk2dTextMesh txtMaxLevel;
    InterstitialAd interstitial;


    

    private void LoadAdsInterstitial()
    {
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(Config.adsInID);
        // Create an empty ad request.
        AdRequest requestIN = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("365BCE5DDF729BFD1E6E40D79CE8F42B").Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(requestIN);
    }

    private void ShowAdsInterstitial()
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


    void callResetDapAn()
    {
         DapAnController.instance.resetDapAN();
         GameController.instance.HideAdsBanner();
    }

    public void setlevel(int level, int maxlevel)
    {
        txtLevel.text = "Vượt qua: Câu " + level;
        txtMaxLevel.text = "Lớn nhất: Câu " + maxlevel;
        LoadAdsInterstitial();
    }

    void btnRate_onClick()
    {
        try
        {
            ShareRate.Rate();
        }
        catch (System.Exception)
        {

            throw;
        }
    }


    void btnContinute_OnClick()
    {
        try
        {
            ShareRate.Share();
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    void btnStop_OnClick()
    {
        try
        {
            if (GameController.instance.level % 3 == 0 || GameController.instance.level % 5 == 0)
            {
                ShowAdsInterstitial();
            }
        SoundController.Instance.PlayTamBiet();
        callResetDapAn();
        PopupController.instance.HidePopupGameOver();
        PopupController.instance.HidePopupKhanGia();
        PopupController.instance.HidePopupNguoiThan();
        PopupController.instance.HidePopUpWin();
        PopupController.instance.ShowMainGame();
        TroGiupControlller.instance.resetHelp();
        GameController.instance.level = 1;
       
        }
        catch (System.Exception)
        {

            throw;
        }
       
    }

	// Use this for initialization
	void Start () {
        btnContinute.OnClick += btnContinute_OnClick;
        btnStop.OnClick += btnStop_OnClick;
        btnRate.OnClick += btnRate_onClick;
        LoadAdsInterstitial();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
