using UnityEngine;
using System.Collections;

public class PopUpWin : MonoBehaviour {

    public tk2dUIItem btnContinute;
    public tk2dTextMesh txtBaDao;

    void btnContinute_OnClick()
    {
        try
        {
            PopupController.instance.HidePopUpWin();
            PopupController.instance.ShowPopupGameOver(15, 15);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

	// Use this for initialization
	void Start () {
        btnContinute.OnClick += btnContinute_OnClick;

        int chon = Random.Range(0, 4);
        if (chon == 1)
        {
            txtBaDao.text = "Bá Đạo";
        }
        else if (chon == 2)
        {
            txtBaDao.text = "Vi Diệu";
        }
        else if (chon == 3)
        {
            txtBaDao.text = "Đỉnh Cao";
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
