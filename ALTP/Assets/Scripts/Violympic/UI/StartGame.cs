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
        SoundController.Instance.PlayClick();

        if (!VioGameController.instance.tienganh)
        {
            if (VioGameController.instance.checkvip != 10)
            {
                AdManager.instance.ShowBanner();
            }
        }
	}

	void onClick_VaoThi()
	{
		VioPopUpController.instance.HideStartGame();

		VioGameController.instance.ShowLevel1();
		VioGameController.instance.ckResetLv = false;

        SoundController.Instance.PlayChoiTiep();
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
