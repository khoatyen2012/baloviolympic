using UnityEngine;
using System.Collections;


public class StopDinhNui : MonoBehaviour {


	public tk2dTextMesh txtDinhNui;
	public tk2dTextMesh txtCoin;
	public tk2dTextMesh txtTime;
	public tk2dTextMesh txtHoanThanh;
	public tk2dUIItem btnContinute;





	public void setData(int pCoin, string pTime)
	{
        
		if (VioGameController.instance.checkvip != 10) {
			if (VioGameController.instance.tienganh && VioGameController.instance.vuotqua < 3) {

				AdManager.instance.ShowBanner();
			} else {
				AdStartApp.instance.ShowBanner ();
			}
		}

        if (pCoin >= 90)
        {
            SoundController.Instance.PlayCamXuc();
        }

		//nativeExpressAdView.Show();
		txtCoin.text = ClsLanguage.doDiem()+": " + pCoin;
		txtTime.text = ClsLanguage.doTime()+": " + pTime;

	}

	void onClick_btnContinute()
	{

		VioPopUpController.instance.HideStopDinhNui();

		VioGameController.instance.ShowLevel2();
        SoundController.Instance.StopBG();
        SoundController.Instance.PlayClick();

		if (VioGameController.instance.checkvip != 10) {
			if (VioGameController.instance.tienganh && VioGameController.instance.vuotqua < 3) {

				AdManager.instance.HideBaner();
			} else {
				AdStartApp.instance.HideBanner ();
			}
		}


	}

	// Use this for initialization
	void Start () {
		btnContinute.OnClick += onClick_btnContinute;

		txtHoanThanh.text = ClsLanguage.doHoanThanhBaiThi();
		txtDinhNui.text = ClsLanguage.doTitleDinhNui();
	
	
	}

	// Update is called once per frame
	void Update () {

	}
}
