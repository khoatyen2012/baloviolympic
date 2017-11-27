using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using StartApp;

public class MainController : MonoBehaviour {
    
    public tk2dUIItem btnPlay; 
    public tk2dUIItem btnRank;
    public tk2dUIItem btnBuyVip;
    public tk2dUIItem btnShare;
    public tk2dUIItem btnRate;
  
    int ok = 0;

    BannerView bannerView;

    private void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(Config.adsInIDBanner, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().TagForChildDirectedTreatment(true).AddExtra("is_designed_for_families", "true").Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

  

    void btnShare_OnClick()
    {
        ShareRate.Share();
        SoundManager.Instance.PlayAudioChoiTiep();
    }

    void btnRate_OnClick()
    {
        ShareRate.Rate();
        SoundManager.Instance.PlayAudioChoiTiep();
    }

 



    void btnBuyVip_OnClick()
    {
        SoundManager.Instance.PlayAudioChoiTiep();
        PopUpController.instance.ShowBuyItem();
        PopUpController.instance.HideMainGame();

        if (GameController.instance.checkvip != 10)
        {
            bannerView.Hide();
        }
    }

    void btnRank_OnClick()
    {
        SoundManager.Instance.PlayAudioChoiTiep();

        if (GameController.instance.vuotqua < 1)
        {
            PopUpController.instance.HideMainGame();
            PopUpController.instance.ShowAdTriger();
         
        }
        else
        {
            if (ok % 2 == 0)
            {
                SceneManager.LoadScene("Rank");
                SoundManager.Instance.StopBGMusic();
            }
            else
            {
                PopUpController.instance.HideMainGame();
                PopUpController.instance.ShowAdTriger();
            }
        }

        if (GameController.instance.checkvip != 10)
        {
            bannerView.Hide();
        }
    }


    void btnPlay_OnClick()
    {
        PopUpController.instance.HideMainGame();
        PopUpController.instance.ShowLevel();
        SoundManager.Instance.PlayAudioChoiTiep();

        if (GameController.instance.checkvip != 10)
        {
            if (GameController.instance.tienganh)
            {
                bannerView.Hide();
            }
            else
            {
               #if UNITY_ANDROID
                StartAppWrapper.removeBanner(StartAppWrapper.BannerPosition.TOP);
                #endif
            }
        }

    }

    public void setData()
    {
        if (GameController.instance.vuotqua < 1)
        {
            btnRank.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doQuangCao();
            
        }
        else
        {
            ok= UnityEngine.Random.Range(0, 9);

            if (ok % 2 == 0)
            {

                btnRank.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doXepHang();
            }
            else
            {
                btnRank.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doQuangCao();
            }
        }

        if (GameController.instance.checkvip != 10)
        {
            if (GameController.instance.tienganh)
            {
                RequestBanner();
                bannerView.Show();
            }
            else
            {
             #if UNITY_ANDROID
                StartAppWrapper.addBanner(
                      StartAppWrapper.BannerType.AUTOMATIC,
                      StartAppWrapper.BannerPosition.TOP);
             #endif
            }
        }
    }

	// Use this for initialization
	void Start () {
        btnRank.OnClick += btnRank_OnClick;
        btnPlay.OnClick += btnPlay_OnClick;
        btnBuyVip.OnClick += btnBuyVip_OnClick;
        btnShare.OnClick += btnShare_OnClick;
        btnRate.OnClick += btnRate_OnClick;
    
        btnPlay.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doVaoThi();      
        btnBuyVip.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doMuaVip();
        setData();
       
        if (GameController.instance.checkvip == 10)
        {
            btnBuyVip.gameObject.SetActive(false);
        }

#if UNITY_ANDROID
        StartAppWrapper.init();
#endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
