using UnityEngine;
using System.Collections;


public class Advertise : MonoBehaviour {

    public tk2dUIItem btnContinute;
    public tk2dUIItem btnCancel;
    public tk2dTextMesh txtTitle;
    public tk2dTextMesh txtContent;
 

 

  

    void onClick_Continute()
    {
		
		if (VioGameController.instance.tienganh && VioGameController.instance.vuotqua < 3) {

				AdManager.instance.ShowAdsInterstitial();
			} else {
				AdStartApp.instance.ShowFull();
			}

       
    }
    void onClick_Cancel()
    {
        VioPopUpController.instance.HideAdTriger();
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

    public void setData()
    {
        AdManager.instance.LoadAdsInterstitial();
    }

	// Use this for initialization
	void Start () {
        btnContinute.OnClick += onClick_Continute;
        btnCancel.OnClick += onClick_Cancel;
        txtTitle.text = ClsLanguage.doQuangCao();
        txtContent.text = ClsLanguage.doContenQuangCao();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
