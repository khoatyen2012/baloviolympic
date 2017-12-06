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

	public tk2dSprite spMonkey;
	public GameObject mThaoTac;
	public GameObject mBangHoi;

	public enum State
	{
		Start,
		InGame,
		Click,
		XuLyT,
		XyLyF,
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
		currentState = State.InGame;

	}

	public void doSubGet(ref List<ThongThai> lst)
	{
		if (lst.Count > 0)
		{
			int chon = UnityEngine.Random.Range(0, lst.Count);
			sttQuestion++;
			txtContent.text = ClsLanguage.doQuestion ()+" "+sttQuestion+":"+ "\n" + lst [chon].Question;
			mKetQuaDung = lst [chon].Ketqua;
			if(lst [chon].Giaithich.Equals("gta")||lst [chon].Giaithich.Equals(""))
			{
				txtGiaiThich.text = ClsLanguage.doQuestion () + " " + sttQuestion + ":" + "\n" + lst [chon].Question + "\n\n" + ClsLanguage.doDapSo ()+mKetQuaDung;
			}else
			{
                txtGiaiThich.text = ClsLanguage.doQuestion() + " " + sttQuestion + ":" + "\n" + lst[chon].Question + "\n\n" + ClsLanguage.doDapSo() + lst[chon].Giaithich;
			}
			txtContent.gameObject.SetActive (true);
			txtGiaiThich.gameObject.SetActive (false);
			mThaoTac.SetActive (true);
			spMonkey.SetSprite ("khihoi");
            mBangHoi.transform.localPosition = startPosvisi;
            stSum = "";
            txtKetQua.text = "";

			lst.RemoveAt(chon);
		}
	}

    public void btnNopBai_OnClick()
    {
        if (!stSum.Equals(""))
        {
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
        }
        else
        {
            spMonkey.SetSprite("khikhoc");
            diemSo = diemSo - 1;
            demsai++;
            txtContent.gameObject.SetActive(false);
            txtGiaiThich.gameObject.SetActive(true);
        }


    }

    IEnumerator WaitTimeXuLyDung(float time)
    {
        yield return new WaitForSeconds(time);
        if (sttQuestion >= 10)
        {
            doSubGet(ref lstLevel);
        }
        else
        {
            //end game
        }
    }

    public void resetDefault()
    {
        stSum="";
	    mKetQuaDung=0;
        diemSo = 0;
        demsai = 0;
        sttQuestion = 0;
    }

	public void btnNumb0_OnClick()
	{
		
	
			stSum += btnNumb0.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
		if ((int.Parse (stSum) + "").Length < 8) {
			txtKetQua.text = int.Parse (stSum) + "";
		} else {
			stSum = stSum.Remove (stSum.Length - 1, 1);
		}
		
	}
	public void btnNumb1_OnClick()
	{
			stSum += btnNumb1.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;

			if ((int.Parse (stSum) + "").Length < 8) {
				txtKetQua.text = int.Parse (stSum) + "";
			} else {
			stSum = stSum.Remove (stSum.Length - 1, 1);
			}
	}
	public void btnNumb2_OnClick()
	{
		stSum += btnNumb2.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
		if ((int.Parse (stSum) + "").Length < 8) {
			txtKetQua.text = int.Parse (stSum) + "";
		} else {
			stSum = stSum.Remove (stSum.Length - 1, 1);
		}
	}
	public void btnNumb3_OnClick()
	{
		stSum += btnNumb3.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
		if ((int.Parse (stSum) + "").Length < 8) {
			txtKetQua.text = int.Parse (stSum) + "";
		} else {
			stSum = stSum.Remove (stSum.Length - 1, 1);
		}
	}
	public void btnNumb4_OnClick()
	{
		stSum += btnNumb4.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
		if ((int.Parse (stSum) + "").Length < 8) {
			txtKetQua.text = int.Parse (stSum) + "";
		} else {
			stSum = stSum.Remove (stSum.Length - 1, 1);
		}
	}
	public void btnNumb5_OnClick()
	{

		stSum += btnNumb5.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
		if ((int.Parse (stSum) + "").Length < 8) {
			txtKetQua.text = int.Parse (stSum) + "";
		} else {
			stSum = stSum.Remove (stSum.Length - 1, 1);
		}
	}
	public void btnNumb6_OnClick()
	{
		stSum += btnNumb6.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
		if ((int.Parse (stSum) + "").Length < 8) {
			txtKetQua.text = int.Parse (stSum) + "";
		} else {
			stSum = stSum.Remove (stSum.Length - 1, 1);
		}
	}
	public void btnNumb7_OnClick()
	{
		stSum += btnNumb7.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
		if ((int.Parse (stSum) + "").Length < 8) {
			txtKetQua.text = int.Parse (stSum) + "";
		} else {
			stSum = stSum.Remove (stSum.Length - 1, 1);
		}
	}
	public void btnNumb8_OnClick()
	{
		stSum += btnNumb8.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
		if ((int.Parse (stSum) + "").Length < 8) {
			txtKetQua.text = int.Parse (stSum) + "";
		} else {
			stSum = stSum.Remove (stSum.Length - 1, 1);
		}
	}
	public void btnNumb9_OnClick()
	{
		stSum += btnNumb9.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text;
		if ((int.Parse (stSum) + "").Length < 8) {
			txtKetQua.text = int.Parse (stSum) + "";
		} else {
			stSum = stSum.Remove (stSum.Length - 1, 1);
		}
	}
	public void btnDelete_OnClick()
	{
		stSum = "";
		txtKetQua.text = "";
	}
	public void btnBack_OnClick()
	{
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

        startPosvisi = mBangHoi.gameObject.transform.localPosition;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
