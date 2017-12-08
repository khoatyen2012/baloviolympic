using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestionMonkey : MonoBehaviour {


	public tk2dTextMesh txtContent;
	public tk2dTextMesh txtGiaiThich;
	public tk2dTextMesh txtTime;
	public tk2dTextMesh txtKetQua;
	public tk2dUIItem btnNopBai;
	public tk2dUIItem btnNumb1;
	public tk2dUIItem btnNumb2;
	public tk2dUIItem btnNumb3;
	public tk2dUIItem btnNumb4;
	public tk2dUIItem btnNumb5;
	public tk2dUIItem btnNumb6;
	public tk2dUIItem btnNumb7;
	public tk2dUIItem btnNumb8;
	public tk2dUIItem btnNumb9;
	public tk2dUIItem btnNumb0;
	public tk2dUIItem btnBack;
	public tk2dUIItem btnDelete;
	public tk2dUIItem btnContinute;

	public tk2dSprite spMonkey;
	public GameObject mThaoTac;
	public GameObject mBangHoi;

	public enum State
	{
		Start,
		InGame,
		XuLy,
		XuLyT,
		XuLyF,
		Stop
	}

	public State currentState;

	public List<ThongThai> lstLevel = new List<ThongThai>();
	
	public string stSum="";
	public int mKetQuaDung=0;

    public int diemSo = 0;
    public int demsai = 0;
    public int sttQuestion = 0;
    public Vector3 startPosvisi;

	int mTime = 1200;

	int demframe = 0;
 

	public void getDataLevel()
	{

		foreach (ThongThai item in VioGameController.instance.lstThongThai)
		{
			if (item.Level == VioGameController.instance.level)
			{
				lstLevel.Add(item);
               
			}
		}

		doSubGet(ref lstLevel);


	}

	public void doSubGet(ref List<ThongThai> lst)
	{
		if (lst.Count > 0)
		{
			currentState = State.InGame;
			int chon = UnityEngine.Random.Range(0, lst.Count);
			sttQuestion++;
			txtContent.text = ClsLanguage.doQuestion ()+" "+sttQuestion+":"+ "\n" + lst [chon].Question;
			mKetQuaDung = lst [chon].Ketqua;
			if (VioGameController.instance.checkvip == 10 || VioGameController.instance.level == 1) {
				
				if (lst [chon].Giaithich.Equals ("gta") || lst [chon].Giaithich.Equals ("")) {
					txtGiaiThich.text = ClsLanguage.doQuestion () + " " + sttQuestion + ":" + "\n" + lst [chon].Question + "\n\n" + ClsLanguage.doDapSo () + mKetQuaDung;
				} else {
					txtGiaiThich.text = ClsLanguage.doQuestion () + " " + sttQuestion + ":" + "\n" + lst [chon].Question + "\n\n" + ClsLanguage.doDapSo () + lst [chon].Giaithich;
				}
			} else {
				txtGiaiThich.text = ClsLanguage.doQuestion () + " " + sttQuestion + ":" + "\n" + lst [chon].Question + "\n\n" + ClsLanguage.doDapSo () + mKetQuaDung+ClsLanguage.doBanCanMuaVip();
			}
			txtContent.gameObject.SetActive (true);
			txtGiaiThich.gameObject.SetActive (false);
			mThaoTac.SetActive (true);
			spMonkey.SetSprite ("khihoi");
            mBangHoi.transform.localPosition = startPosvisi;
            stSum = "";
            txtKetQua.text = "";
			btnContinute.gameObject.SetActive (false);

			lst.RemoveAt(chon);
		}
	}

    public void btnNopBai_OnClick()
    {
        if (!stSum.Equals(""))
        {
			currentState = State.XuLy;
            spMonkey.SetSprite("khixet");
            mThaoTac.SetActive(false);
            StartCoroutine(WaitTimeXuLy(2f));
        }
        else
        {
        }
    }

    IEnumerator WaitTimeXuLy(float time)
    {
        yield return new WaitForSeconds(time);
        if (int.Parse(stSum) == mKetQuaDung)
        {
            spMonkey.SetSprite("khicuoi");
            diemSo = diemSo + 10;
            mBangHoi.transform.localPosition = new Vector3(startPosvisi.x, 85f, startPosvisi.z);
            StartCoroutine(WaitTimeXuLyDung(2f));
			currentState = State.XuLyT;
        }
        else
        {
            spMonkey.SetSprite("khikhoc");
            diemSo = diemSo - 1;
            demsai++;
            txtContent.gameObject.SetActive(false);
            txtGiaiThich.gameObject.SetActive(true);
			btnContinute.gameObject.SetActive (true);
			currentState = State.XuLyF;
        }


    }

    IEnumerator WaitTimeXuLyDung(float time)
    {
        yield return new WaitForSeconds(time);
        if (sttQuestion < 10)
        {
            doSubGet(ref lstLevel);
        }
        else
        {
			gameOver ();
        }
    }

    public void resetDefault()
    {
        stSum="";
	    mKetQuaDung=0;
        diemSo = 0;
        demsai = 0;
        sttQuestion = 0;
		mTime = 1200;
		demframe = 0;
		lstLevel.Clear ();
    }

	void gameOver()
	{


		currentState = State.Stop;
		if (diemSo < 0)
		{
			diemSo = 0;
		}
		VioGameController.instance.sumCoin += diemSo;
		VioGameController.instance.sumTime += mTime;
		VioPopUpController.instance.ShowStopThongThai(diemSo, ClsThaoTac.CoverTimeToString(1200 - mTime));
		VioPopUpController.instance.HideQuestionMonkey();
		resetDefault();
	}

	public void btnContinute_OnClick()
	{
		if (sttQuestion <10 && demsai<3)
		{
			doSubGet(ref lstLevel);
		}
		else
		{
			gameOver ();
		}
	}

	public void btnNumb0_OnClick()
	{
		
		if (currentState == State.InGame) {
			stSum += btnNumb0.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
			if ((int.Parse (stSum) + "").Length < 9) {
				txtKetQua.text = int.Parse (stSum) + "";
			} else {
				stSum = stSum.Remove (stSum.Length - 1, 1);
			}
		}
		
	}
	public void btnNumb1_OnClick()
	{
		if (currentState == State.InGame) {
			stSum += btnNumb1.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;

			if ((int.Parse (stSum) + "").Length < 9) {
				txtKetQua.text = int.Parse (stSum) + "";
			} else {
				stSum = stSum.Remove (stSum.Length - 1, 1);
			}
		}
	}
	public void btnNumb2_OnClick()
	{
		if (currentState == State.InGame) {
			stSum += btnNumb2.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
			if ((int.Parse (stSum) + "").Length < 9) {
				txtKetQua.text = int.Parse (stSum) + "";
			} else {
				stSum = stSum.Remove (stSum.Length - 1, 1);
			}
		}
	}
	public void btnNumb3_OnClick()
	{
		if (currentState == State.InGame) {
			stSum += btnNumb3.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
			if ((int.Parse (stSum) + "").Length < 9) {
				txtKetQua.text = int.Parse (stSum) + "";
			} else {
				stSum = stSum.Remove (stSum.Length - 1, 1);
			}
		}
	}
	public void btnNumb4_OnClick()
	{
		if (currentState == State.InGame) {
			stSum += btnNumb4.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
			if ((int.Parse (stSum) + "").Length < 9) {
				txtKetQua.text = int.Parse (stSum) + "";
			} else {
				stSum = stSum.Remove (stSum.Length - 1, 1);
			}
		}
	}
	public void btnNumb5_OnClick()
	{
		if (currentState == State.InGame) {
			stSum += btnNumb5.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
			if ((int.Parse (stSum) + "").Length < 9) {
				txtKetQua.text = int.Parse (stSum) + "";
			} else {
				stSum = stSum.Remove (stSum.Length - 1, 1);
			}
		}
	}
	public void btnNumb6_OnClick()
	{
		if (currentState == State.InGame) {
			stSum += btnNumb6.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
			if ((int.Parse (stSum) + "").Length < 9) {
				txtKetQua.text = int.Parse (stSum) + "";
			} else {
				stSum = stSum.Remove (stSum.Length - 1, 1);
			}
		}
	}
	public void btnNumb7_OnClick()
	{
		if (currentState == State.InGame) {
			stSum += btnNumb7.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
			if ((int.Parse (stSum) + "").Length < 9) {
				txtKetQua.text = int.Parse (stSum) + "";
			} else {
				stSum = stSum.Remove (stSum.Length - 1, 1);
			}
		}
	}
	public void btnNumb8_OnClick()
	{
		if (currentState == State.InGame) {
			stSum += btnNumb8.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
			if ((int.Parse (stSum) + "").Length < 9) {
				txtKetQua.text = int.Parse (stSum) + "";
			} else {
				stSum = stSum.Remove (stSum.Length - 1, 1);
			}
		}
	}
	public void btnNumb9_OnClick()
	{
		if (currentState == State.InGame) {
			stSum += btnNumb9.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
			if ((int.Parse (stSum) + "").Length < 9) {
				txtKetQua.text = int.Parse (stSum) + "";
			} else {
				stSum = stSum.Remove (stSum.Length - 1, 1);
			}
		}
	}
	public void btnDelete_OnClick()
	{
		if (currentState == State.InGame) {
			stSum = "";
			txtKetQua.text = "";
		}
	}
	public void btnBack_OnClick()
	{
		if (currentState == State.InGame) {
			if (!stSum.Trim ().Equals ("")) {
				stSum = stSum.Remove (stSum.Length - 1, 1);

				if (stSum.Trim ().Equals ("")) {
					txtKetQua.text = "";
				} else {
					txtKetQua.text = int.Parse (stSum) + "";
				}

			} else {
			}
		}
	}
	




	// Use this for initialization
	void Start () {

		btnBack.OnClick += btnBack_OnClick;
		btnDelete.OnClick += btnDelete_OnClick;
		btnNopBai.OnClick += btnNopBai_OnClick;
		btnNumb0.OnClick += btnNumb0_OnClick;
		btnNumb1.OnClick += btnNumb1_OnClick;
		btnNumb2.OnClick += btnNumb2_OnClick;
		btnNumb3.OnClick += btnNumb3_OnClick;
		btnNumb4.OnClick += btnNumb4_OnClick;
		btnNumb5.OnClick += btnNumb5_OnClick;
		btnNumb6.OnClick += btnNumb6_OnClick;
		btnNumb7.OnClick += btnNumb7_OnClick;
		btnNumb8.OnClick += btnNumb8_OnClick;
		btnNumb9.OnClick += btnNumb9_OnClick;
		btnContinute.OnClick += btnContinute_OnClick;
		btnNopBai.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text = ClsLanguage.doSumit ();

        startPosvisi = mBangHoi.gameObject.transform.localPosition;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (currentState != State.Start&&currentState!=State.Stop)
		{
			//đếm ngược thời gian từ 20 phút
			if (demframe < 30)
			{
				demframe++;
			}
			else
			{
				mTime--;
				txtTime.text = ClsThaoTac.CoverTimeToString(mTime);
				//if (mTime <= 10)
				//{
				//    txtTime.color = new Color(1, 0, 1, 1);
				//}

				demframe = 0;
				if (mTime <= 0)
				{
					//currentState = State.Stop;
					//hết giờ thì game over
					gameOver ();
				}
			}
		}

	}
}
