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
		//SoundManager.Instance.rePlayBGMusic();
		if (VioGameController.instance.checkvip != 10)
		{
//Quang cao
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

		if (VioGameController.instance.checkvip != 10)
		{
			//Hide quang cao
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
