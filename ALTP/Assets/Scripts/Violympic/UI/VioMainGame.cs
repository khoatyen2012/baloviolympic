using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VioMainGame : MonoBehaviour {


	public tk2dUIItem btnPlay;
	public tk2dUIItem btnBuyVip;
	public tk2dUIItem btnALTP;
    public tk2dUIItem btnShare;
    public tk2dUIItem btnRate;


    void onClick_Share()
    {
        ShareRate.Share();
    }

    void onClick_Rate()
    {
        if (VioGameController.instance.tienganh)
        {
            ShareRate.Rate();
        }
        else
        {
            ShareRate.RateBird();
        }
    }

	void onClick_Play()
	{
		VioPopUpController.instance.ShowLevel ();
		VioPopUpController.instance.HideMainGame ();
        SoundController.Instance.PlayClick();

        if (VioGameController.instance.tienganh)
        {
            if (VioGameController.instance.checkvip != 10)
            {
                AdManager.instance.HideBaner();
            }
        }

	}
	void onClick_BuyVip()
	{
		VioPopUpController.instance.HideMainGame ();
        VioPopUpController.instance.ShowBuyItem();
        SoundController.Instance.PlayClick();
        if (VioGameController.instance.checkvip != 10)
        {
            AdManager.instance.HideBaner();
        }
	}
	void onClick_ALTP()
	{
        SoundController.Instance.PlayClick();
		VioPopUpController.instance.HideMainGame ();
        if (VioGameController.instance.checkvip != 10)
        {
            AdManager.instance.HideBaner();
        }

        if (!VioGameController.instance.tienganh)
        {
            SceneManager.LoadScene("InGame");
        }
        else
        {
            
            VioPopUpController.instance.ShowAdTriger();
        }
	}

	public void setData()
	{
		
	}

	// Use this for initialization
	void Start () {
		btnPlay.OnClick += onClick_Play;
		btnBuyVip.OnClick += onClick_BuyVip;
		btnALTP.OnClick += onClick_ALTP;
        btnRate.OnClick += onClick_Rate;
        btnShare.OnClick += onClick_Share;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
