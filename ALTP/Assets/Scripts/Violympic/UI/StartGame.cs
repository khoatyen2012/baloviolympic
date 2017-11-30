using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public tk2dUIItem btnVaoThi;
	public tk2dUIItem btnBack;
	public tk2dTextMesh txtTitle;
	public tk2dTextMesh txtContent;


	void onClick_Back()
	{
		VioPopUpController.instance.HideStartGame();
		VioPopUpController.instance.ShowLevel();
	}

	void onClick_VaoThi()
	{
		VioPopUpController.instance.HideStartGame();

		VioGameController.instance.ShowLevel1();
		VioGameController.instance.ckResetLv = false;

		//SoundManager.Instance.PlayAudioChoiTiep();
	}
	public void setData()
	{
		txtTitle.text = ClsLanguage.doBatDau() + VioGameController.instance.level;

	}

	// Use this for initialization
	void Start () {
		btnVaoThi.OnClick += onClick_VaoThi;
		btnBack.OnClick += onClick_Back;

		txtContent.text = ClsLanguage.doContentBatDau();

	}

	// Update is called once per frame
	void Update () {

	}
}
