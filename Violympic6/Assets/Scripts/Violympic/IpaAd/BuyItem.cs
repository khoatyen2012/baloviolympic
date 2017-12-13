using UnityEngine;
using System.Collections;

public class BuyItem : MonoBehaviour
{

    public tk2dTextMesh txtTitle;
    public tk2dTextMesh txtContent;
    public tk2dUIItem btnCancel;
    public tk2dUIItem btnBuy;

    void btnCancel_OnClick()
    {

        VioPopUpController.instance.HideBuyItem();
        VioPopUpController.instance.ShowMainGame();
        SoundController.Instance.PlayClick();
		if (VioGameController.instance.checkvip != 10) {
			if (VioGameController.instance.tienganh && VioGameController.instance.vuotqua < 3) {

				AdManager.instance.ShowBanner();
			} else {
				AdStartApp.instance.ShowBanner ();
			}
		}
       
    }

    void btnBuy_OnClick()
    {

        IAPManager.instance.BuyVipLevel();
        SoundController.Instance.PlayClick();
    }

    // Use this for initialization
    void Start()
    {

        btnCancel.OnClick += btnCancel_OnClick;
        btnBuy.OnClick += btnBuy_OnClick;
        txtTitle.text = ClsLanguage.doActiVip();
        txtContent.text = ClsLanguage.doContenVip();


    }

    // Update is called once per frame
    void Update()
    {

    }
}
