using UnityEngine;
using System.Collections;

public class HoanThanh : MonoBehaviour {

	public tk2dTextMesh txtTitle;
	public tk2dTextMesh txtContent;
	public tk2dUIItem btnContinute;

	void onClick_btnContinute()
	{
		VioPopUpController.instance.HideHoanThanh();
		VioPopUpController.instance.ShowLevel();
	}

	// Use this for initialization
	void Start () {
		btnContinute.OnClick += onClick_btnContinute;
		txtTitle.text = ClsLanguage.doTitleTuyetVoi();
		txtContent.text = ClsLanguage.doContentTuyetVoi();
	
	}

	// Update is called once per frame
	void Update () {

	}
}
