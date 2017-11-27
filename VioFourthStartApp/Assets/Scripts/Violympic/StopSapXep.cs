﻿using UnityEngine;
using System.Collections;

public class StopSapXep : MonoBehaviour {

    public tk2dTextMesh txtDiem;
    public tk2dTextMesh txtTime;
    public tk2dTextMesh txtTitle;
    public tk2dTextMesh txtHoanThanh;
    public tk2dUIItem btnContinute;

    public void setData(int diem, string time)
    {
        SoundManager.Instance.rePlayBGMusic();
        txtDiem.text = ClsLanguage.doDiem() + ": " + diem;
        txtTime.text = ClsLanguage.doTime() + ": " + time;
    }

    void btnContinute_OnClick()
    {
        PopUpController.instance.HideStopSapXep();
        GameController.instance.ShowLevel2();
    }

    // Use this for initialization
    void Start()
    {
        btnContinute.OnClick += btnContinute_OnClick;
        txtTitle.text = ClsLanguage.doTileSapXep();
        txtHoanThanh.text = ClsLanguage.doHoanThanhBaiThi();
        btnContinute.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doContinute();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
