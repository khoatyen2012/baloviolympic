using UnityEngine;
using System.Collections;


public class StopGame : MonoBehaviour {

	public tk2dSprite sa_Nguoi;
	public tk2dTextMesh txtHoanThanh;
	public tk2dTextMesh txtTitle;
	public tk2dTextMesh txtTongDiem;
	public tk2dUIItem btnContinute;
	public tk2dSprite rate;





	void onClick_Continute()
	{
		if (VioGameController.instance.checkvip != 10)
		{
			//Quang cap
		}

		VioPopUpController.instance.HideStopGame();
		if (VioGameController.instance.level < 21)
		{
			VioPopUpController.instance.ShowStartGame();
		}
		else
		{
			VioPopUpController.instance.ShowHoanThanh();
		}
		VioGameController.instance.sumCoin = 0;
		VioGameController.instance.sumTime = 0;
	}





	public void setData()
	{


		if (VioGameController.instance.sumCoin < 150)
		{
			txtHoanThanh.text = ClsLanguage.doChuaVuotQua() + VioGameController.instance.level;
			rate.SetSprite("khongsao");
			sa_Nguoi.SetSprite("traloisai");
			int chon = UnityEngine.Random.Range(0, 2);
			if (chon == 0)
			{
				//SoundManager.Instance.PlayAudioChucMung1();
			}
			else
			{
				//SoundManager.Instance.PlayAudioChucMung2();
			}
		}
		else
		{
			txtHoanThanh.text = ClsLanguage.doVuotQua() + VioGameController.instance.level;
			if (VioGameController.instance.sumCoin >= 180)
			{
				rate.SetSprite("basao");
			}
			else if (VioGameController.instance.sumCoin > 150)
			{
				rate.SetSprite("haisao");
			}
			else
			{
				rate.SetSprite("motsao");
			}
			sa_Nguoi.SetSprite("traloidung");
			//SoundManager.Instance.PlayAudioChucMung3();


			//luu diem vao tong diem
			VioGameController.instance.stSumcoin = "";
			if (int.Parse(VioGameController.instance.mang[VioGameController.instance.level-1]) < VioGameController.instance.sumCoin)
			{
				VioGameController.instance.mang[VioGameController.instance.level - 1] = "" + VioGameController.instance.sumCoin;
			}

			VioGameController.instance.stSumcoin = VioGameController.instance.mang[0];
			for (int i = 1; i < VioGameController.instance.mang.Length; i++)
			{
				VioGameController.instance.stSumcoin =VioGameController.instance.stSumcoin+"+"+ VioGameController.instance.mang[i];
			}
			DataManager.SaveHightStringCoin(VioGameController.instance.stSumcoin);


			//lu so giay tat ca 3 vong
			if (VioGameController.instance.level > VioGameController.instance.vuotqua)
			{
				DataManager.SaveHightSecond(VioGameController.instance.sumTime);
			}



			//luu level vuot qua
			if (VioGameController.instance.vuotqua < VioGameController.instance.level)
			{
				VioGameController.instance.vuotqua = VioGameController.instance.level;
				DataManager.SaveHightLevel(VioGameController.instance.level);
			}

			VioGameController.instance.level++;
		}
		txtTongDiem.text = ClsLanguage.doTongDiem() + VioGameController.instance.sumCoin + "/200";

	}

	// Use this for initialization
	void Start () {

		btnContinute.OnClick += onClick_Continute;

		txtTitle.text = ClsLanguage.doTongKet();
	

	}

	// Update is called once per frame
	void Update () {

	}
}
