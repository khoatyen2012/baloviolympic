using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using StartApp;

public class StopDinhNui : MonoBehaviour {


    public tk2dTextMesh txtDinhNui;
    public tk2dTextMesh txtCoin;
    public tk2dTextMesh txtTime;
    public tk2dTextMesh txtHoanThanh;
    public tk2dUIItem btnContinute;


    BannerView bannerView;

    private void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(Config.adsInIDBanner, AdSize.Banner, AdPosition.TopLeft);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().TagForChildDirectedTreatment(true).AddExtra("is_designed_for_families", "true").Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }


    
    public void setData(int pCoin, string pTime)
    {
        SoundManager.Instance.rePlayBGMusic();
        if (GameController.instance.checkvip != 10)
        {
			if (GameController.instance.tienganh) {
				RequestBanner ();
				bannerView.Show ();
			} else {
				#if UNITY_ANDROID
				StartAppWrapper.addBanner(
					StartAppWrapper.BannerType.AUTOMATIC,
					StartAppWrapper.BannerPosition.TOP);
				#endif
			}
        }
       
        //nativeExpressAdView.Show();
        txtCoin.text = ClsLanguage.doDiem()+": " + pCoin;
        txtTime.text = ClsLanguage.doTime()+": " + pTime;
    }

    void onClick_btnContinute()
    {

        PopUpController.instance.HideStopDinhNui();
     
            GameController.instance.ShowLevel3();

            if (GameController.instance.checkvip != 10)
            {
			    if (GameController.instance.tienganh) {
				  bannerView.Hide ();
			    }else
			   {
				#if UNITY_ANDROID
				StartAppWrapper.removeBanner(StartAppWrapper.BannerPosition.TOP);
				#endif
			   }
            }
    }

	// Use this for initialization
	void Start () {
        btnContinute.OnClick += onClick_btnContinute;

        txtHoanThanh.text = ClsLanguage.doHoanThanhBaiThi();
        txtDinhNui.text = ClsLanguage.doTitleDinhNui();
        btnContinute.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doContinute();
		#if UNITY_ANDROID
		StartAppWrapper.init();
		#endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
