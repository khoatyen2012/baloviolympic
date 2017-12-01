using UnityEngine;
using System.Collections;

public class VioMainGame : MonoBehaviour {


	public tk2dUIItem btnPlay;
	public tk2dUIItem btnBuyVip;
	public tk2dUIItem btnALTP;

	void onClick_Play()
	{
		VioPopUpController.instance.ShowLevel ();
		VioPopUpController.instance.HideMainGame ();

	}
	void onClick_BuyVip()
	{
		VioPopUpController.instance.HideMainGame ();
	}
	void onClick_ALTP()
	{
		VioPopUpController.instance.HideMainGame ();
	}

	public void setData()
	{
		
	}

	// Use this for initialization
	void Start () {
		btnPlay.OnClick += onClick_Play;
		btnBuyVip.OnClick += onClick_BuyVip;
		btnALTP.OnClick += onClick_ALTP;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
