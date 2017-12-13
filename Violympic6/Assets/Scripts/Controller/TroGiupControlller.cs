using UnityEngine;
using System.Collections;

public class TroGiupControlller : MonoBehaviour {


    public tk2dUIItem btnNamMuoi;
    public tk2dUIItem btnHoiYKien;
    public tk2dUIItem btnHoiNguoiThan;
    public tk2dUIItem btnDoiCauHoi;


    #region Singleton
    private static TroGiupControlller _instance;

    public static TroGiupControlller instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<TroGiupControlller>();
            return _instance;
        }
    }
    #endregion


    public void resetHelp()
    {
        btnNamMuoi.gameObject.GetComponent<tk2dSprite>().SetSprite("nammuoi");
        btnNamMuoi.gameObject.GetComponent<BoxCollider>().enabled = true;
        btnHoiYKien.gameObject.GetComponent<tk2dSprite>().SetSprite("hoikhangia");
        btnHoiYKien.gameObject.GetComponent<BoxCollider>().enabled = true;
        btnHoiNguoiThan.gameObject.GetComponent<tk2dSprite>().SetSprite("nguoithan");
        btnHoiNguoiThan.gameObject.GetComponent<BoxCollider>().enabled = true;
        btnDoiCauHoi.gameObject.GetComponent<tk2dSprite>().SetSprite("doicauhoi");
        btnDoiCauHoi.gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    IEnumerator WaitTimeNamMUoi(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        GameController.instance.helpNamMuoi();


    }

    IEnumerator WaitTimeKhanGia(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        PopupController.instance.ShowPopupKhanGia();


    }

    void btnNamMuoi_Onlick()
    {
        try{
        if (GameController.instance.currentState == GameController.State.Question)
        {
            GameController.instance.currentState = GameController.State.Help;
            SoundController.Instance.PlayNamMuoi();
            StartCoroutine(WaitTimeNamMUoi(4f));
            btnNamMuoi.gameObject.GetComponent<tk2dSprite>().SetSprite("nammuoi2");
            btnNamMuoi.gameObject.GetComponent<BoxCollider>().enabled=false;
        }
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    void btnHoiYKien_Onlick()
    {
        try
        {
        if (GameController.instance.currentState == GameController.State.Question)
        {
            
            GameController.instance.currentState = GameController.State.Help;
            SoundController.Instance.PlayKhanGia();
            btnHoiYKien.gameObject.GetComponent<tk2dSprite>().SetSprite("hoikhangia1");
            btnHoiYKien.gameObject.GetComponent<BoxCollider>().enabled = false;
            DapAnController.instance.doSetEnabal(false);
            StartCoroutine(WaitTimeKhanGia(6f));
        }
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    void btnHoiNguoiThan_Onlick()
    {
        try
        {
            if (GameController.instance.currentState == GameController.State.Question)
            {

                GameController.instance.currentState = GameController.State.Help;

                btnHoiNguoiThan.gameObject.GetComponent<tk2dSprite>().SetSprite("nguoithan2");
                btnHoiNguoiThan.gameObject.GetComponent<BoxCollider>().enabled = false;
                DapAnController.instance.doSetEnabal(false);
                PopupController.instance.ShowPopUpNguoiThan();
				AdStartApp.instance.ShowBanner();

            }
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    void btnDoiCauHoi_Onlick()
    {
        try
        {
            if (GameController.instance.currentState == GameController.State.Question)
            {
                btnDoiCauHoi.gameObject.GetComponent<tk2dSprite>().SetSprite("doicauhoi2");
                btnDoiCauHoi.gameObject.GetComponent<BoxCollider>().enabled = false;
                GameController.instance.suget();
            }
        }
        catch (System.Exception)
        {

            throw;
        }
    }


  

	// Use this for initialization
	void Start () {
        btnNamMuoi.OnClick += btnNamMuoi_Onlick;
        btnHoiYKien.OnClick += btnHoiYKien_Onlick;
        btnHoiNguoiThan.OnClick += btnHoiNguoiThan_Onlick;
        btnDoiCauHoi.OnClick += btnDoiCauHoi_Onlick;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
