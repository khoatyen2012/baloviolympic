using UnityEngine;
using System.Collections;

public class StopThongThai : MonoBehaviour {


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

		//nativeExpressAdView.Show();
		txtCoin.text = ClsLanguage.doDiem()+": " + pCoin;
		txtTime.text = ClsLanguage.doTime()+": " + pTime;
	}

	void onClick_btnContinute()
	{

	

		if (VioGameController.instance.checkvip != 10)
		{
			//Hide quang cao
		}

		VioPopUpController.instance.HideStopThongThai ();
		VioPopUpController.instance.ShowStopGame ();
	}

	// Use this for initialization
	void Start () {
		btnContinute.OnClick += onClick_btnContinute;

		txtHoanThanh.text = ClsLanguage.doHoanThanhBaiThi();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
