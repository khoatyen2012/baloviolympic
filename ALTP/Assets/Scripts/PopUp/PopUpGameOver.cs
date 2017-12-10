using UnityEngine;
using System.Collections;


public class PopUpGameOver : MonoBehaviour {

    public tk2dUIItem btnContinute;
    public tk2dUIItem btnStop;
    public tk2dUIItem btnRate;
    public tk2dTextMesh txtLevel;
    public tk2dTextMesh txtMaxLevel;



    

   


    void callResetDapAn()
    {
         DapAnController.instance.resetDapAN();
         if (GameController.instance.level % 3 == 0 || GameController.instance.level == 5)
         {
             AdManager.instance.HideBaner();
         }

        
    }

    public void setlevel(int level, int maxlevel)
    {
        txtLevel.text = "Vượt qua: Câu " + level;
        txtMaxLevel.text = "Lớn nhất: Câu " + maxlevel;
        AdManager.instance.LoadAdsInterstitial();
        //LoadAdsInterstitial();
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
            AdManager.instance.ShowAdsInterstitial();
        SoundController.Instance.PlayTamBiet(false);
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
        AdManager.instance.LoadAdsInterstitial();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
