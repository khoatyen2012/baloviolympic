using UnityEngine;
using System.Collections;

public class BuyItem : MonoBehaviour
{

    public tk2dTextMesh txtTitle;
    public tk2dTextMesh txtContent;
    public tk2dUIItem btnCancel;
    public tk2dUIItem btnBuy;

    void btnCancel_OnClick()
    {

        VioPopUpController.instance.HideBuyItem();
        VioPopUpController.instance.ShowMainGame();
    }

    void btnBuy_OnClick()
    {

        IAPManager.instance.BuyVipLevel();
    }

    // Use this for initialization
    void Start()
    {

        btnCancel.OnClick += btnCancel_OnClick;
        btnBuy.OnClick += btnBuy_OnClick;
        txtTitle.text = ClsLanguage.doActiVip();
        txtContent.text = ClsLanguage.doContenVip();


    }

    // Update is called once per frame
    void Update()
    {

    }
}
